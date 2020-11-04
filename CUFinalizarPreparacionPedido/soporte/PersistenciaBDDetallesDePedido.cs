using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CUFinalizarPreparacionPedido.soporte
{
    public class PersistenciaBDDetallesDePedido: IGestorPersistencia
    {
        SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");
        public void DesMaterializar(object obj)
        {

        }

        public object MaterializarPorId(object id)
        {
            DetalleDePedido dp;

            String query = @"SELECT [nroDetallePedido],
	                                [nroDetallePedido],
                                    [cantidad],
                                    [hora],
                                    [precio]
                            FROM[FranquiciaRestaurante].[dbo].[DetalleDePedido] DP
                            WHERE IdDetalleDePedido =" + id;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int nroPedido = (int)row[0];
                    int nroDetalle = (int)row[1];
                    int cantidad = (int)row[2];
                    TimeSpan hora = (TimeSpan)row[3];
                    decimal precio = (decimal)row[4];

                    dp = new DetalleDePedido(nroPedido, nroDetalle, cantidad, hora, precio);
                    
                    return dp;
                }
            }

            return null;
        }

        public List<DetalleDePedido> buscarTodosDetallesPedido(List<Estado> estados)
        {
            List<DetalleDePedido> dp = new List<DetalleDePedido>();
            String query = @"SELECT [nroPedido],
	                                [nroDetallePedido],
                                    [cantidad],
                                    [hora],
                                    [precio]
                            FROM [FranquiciaRestaurante].[dbo].[DetalleDePedido] DP";

            SqlCommand sqlCommandEstados = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommandEstados.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int nroPedido = (int)row[0];
                    int nroDetalle = (int)row[1];
                    int cantidad = (int)row[2];
                    TimeSpan hora = (TimeSpan)row[3];
                    decimal precio = (decimal)row[4];

                    dp.Add(new DetalleDePedido(nroPedido, nroDetalle, cantidad, hora, precio));

                }

                sqlDataReader.Close();

                foreach(DetalleDePedido detalle in dp)
                {
                    //Busco sus historiales
                    List<HistorialEstado> historiales = new List<HistorialEstado>();
                    String queryHistorialEstados = @"SELECT HE.fechaHoraInicio,
	                                                        HE.fechaHoraFin,
	                                                        ES.ambito,
	                                                        ES.nombre
                                                    FROM [FranquiciaRestaurante].[dbo].[HistorialEstado] HE
                                                    JOIN [FranquiciaRestaurante].[dbo].[Estado] ES 
                                                                ON HE.idEstado = ES.idEstado
                                                    JOIN [FranquiciaRestaurante].[dbo].[DetalleDePedidoHistorialEstado] DP 
                                                                ON DP.idHistorialEstado = HE.idHistorialEstado
                                                    WHERE DP.nroPedido = " + detalle.getNroPedido() + "AND DP.nroDetallePedido = " + detalle.getNroDetalle();

                    SqlCommand sqlCommandHistorialEstados = new SqlCommand(queryHistorialEstados, cn);

                    SqlDataReader sqlDataReaderHistorial = sqlCommandHistorialEstados.ExecuteReader();
                    while (sqlDataReaderHistorial.Read())
                    {
                        IDataRecord rowHE = (IDataRecord)sqlDataReaderHistorial;
                        Estado es = new Estado();
                        //Busco el puntero del estado vinculado al historial para crearlo
                        foreach (Estado e in estados)
                        {
                            if (e.getAmbito() == (String)rowHE[2] && e.getNombre() == (String)rowHE[3])
                            {
                                es = e;
                                break;
                            }
                        }
                        DateTime fechaHoraInicio = (DateTime)rowHE[0];
                        DateTime? fechaHoraFin = (DateTime?)(rowHE.IsDBNull(1) ? null : (DateTime?)rowHE[1]);
                        
                        historiales.Add(new HistorialEstado(es, fechaHoraInicio, fechaHoraFin));

                    }

                    detalle.setHistorialEstado(historiales);

                    sqlDataReaderHistorial.Close();
                }
            }

            return dp;
        }

        public List<Estado> buscarTodosEstados() { return null; }
    }
}
