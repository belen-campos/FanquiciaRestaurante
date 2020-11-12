using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.soporte
{
    public class PersistenciaBDHistorialEstado
    {
        protected static List<int> idHistorialesMaterializados = new List<int>();
        protected static List<HistorialEstado> historialesMaterializados = new List<HistorialEstado>();

        private static PersistenciaBDEstado persitenciaEstado = new PersistenciaBDEstado();

        private static string conString = "Server=DESKTOP-BJK4AIA;DataBase=FranquiciaRestaurante; Integrated Security=true;";

        public List<HistorialEstado> getHisrotialDetallePedido(int numPedido, int numDetalle, SqlConnection con) 
        {
            List<Estado> estados = PersistenciaBDEstado.getTodosEstados();
            //Busco sus historiales
            List<HistorialEstado> historiales = new List<HistorialEstado>();
            string queryHistorialEstados = @"SELECT HE.fechaHoraInicio,
	                                                        HE.fechaHoraFin,
	                                                        ES.ambito,
	                                                        ES.nombre
                                                    FROM [FranquiciaRestaurante].[dbo].[HistorialEstado] HE
                                                    JOIN [FranquiciaRestaurante].[dbo].[Estado] ES 
                                                                ON HE.idEstado = ES.idEstado
                                                    JOIN [FranquiciaRestaurante].[dbo].[DetalleDePedidoHistorialEstado] DP 
                                                                ON DP.idHistorialEstado = HE.idHistorialEstado
                                                    WHERE DP.nroPedido = " + numPedido + "AND DP.nroDetallePedido = " + numDetalle;

            SqlCommand sqlCommandHistorialEstados = new SqlCommand(queryHistorialEstados, con);

            SqlDataReader sqlDataReaderHistorial = sqlCommandHistorialEstados.ExecuteReader();
            while (sqlDataReaderHistorial.Read())
            {
                IDataRecord rowHE = (IDataRecord)sqlDataReaderHistorial;
                Estado es = null;
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
            sqlDataReaderHistorial.Close();

            return historiales;
        }

        public void setearHistorialEstado(int idHistorial, HistorialEstado ultimo, SqlTransaction tran)
        {
            DateTime fechaHoraFin = ultimo.getFechaHoraFin();

            string query = "UPDATE [FranquiciaRestaurante].[dbo].[HistorialEstado] SET fechaHoraFin = \'" + fechaHoraFin+
                            "\' WHERE idHistorialEstado = " + idHistorial;

            SqlCommand sqlCommand = new SqlCommand(query, tran.Connection);

            sqlCommand.Transaction = tran;

            sqlCommand.ExecuteNonQuery();
        }

        public void crearHistorial(DetalleDePedido detalle, HistorialEstado nuevo, SqlTransaction tran)
        {
            //primero busco el id del estado al que se asociara el historial
            int idEstado = persitenciaEstado.getIdEstado(nuevo.getEstado());

            //busco el ultimo id de los historiales
            string query = @"SELECT MAX(idHistorialEstado)
                            FROM[FranquiciaRestaurante].[dbo].[HistorialEstado]";

            SqlCommand buscarUltimoId = new SqlCommand(query, tran.Connection);
            buscarUltimoId.Transaction = tran;
            
            SqlDataReader sqlDataReader = buscarUltimoId.ExecuteReader();
            
            int idHistorial = 1;
            
            while (sqlDataReader.Read()) 
            {
                IDataRecord row = (IDataRecord)sqlDataReader;
                idHistorial += (int)row[0];
            }
            
            sqlDataReader.Close();
            
            //Primero creo el historial
            string queryNuevoHistorial = @"INSERT INTO [FranquiciaRestaurante].[dbo].[HistorialEstado]
                                                (idHistorialEstado, idEstado, fechaHoraInicio)
                                                VALUES ("+idHistorial+","+idEstado+",\'"+nuevo.getFechaHoraInicio()+"\')";

            SqlCommand crearHistorial = new SqlCommand(queryNuevoHistorial, tran.Connection);
            crearHistorial.Transaction = tran;
            crearHistorial.ExecuteNonQuery();

            //Segundo creo la relacion detalle historial
            string queryRelacionDetalleHistorial = @"INSERT INTO [FranquiciaRestaurante].[dbo].[DetalleDePedidoHistorialEstado]
                                                        ( nroPedido, nroDetallePedido, idHistorialEstado)
                                                        VALUES ("+detalle.getNroPedido()+","+detalle.getNroDetalle()+","+idHistorial+")";

            SqlCommand crearRelacionDetalleHistorial = new SqlCommand(queryRelacionDetalleHistorial, tran.Connection);
            crearRelacionDetalleHistorial.Transaction = tran;
            crearRelacionDetalleHistorial.ExecuteNonQuery();



        }
    }
}
