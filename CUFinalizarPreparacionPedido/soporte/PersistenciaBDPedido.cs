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
    public class PersistenciaBDPedido
    {
        private static PersistenciaBDMesa persitenciaMesa = new PersistenciaBDMesa();

        List<Pedido> pedidosMaterializados = new List<Pedido>();

        private string conString = "Server=DESKTOP-BJK4AIA;DataBase=FranquiciaRestaurante; Integrated Security=true;";

        public object MaterializarPorId(object id)
        {
            SqlConnection cn = new SqlConnection(conString);

            Pedido pedido=null;

            string query = @"SELECT P.[cantComensales],
	                                P.[fechaHoraPed],
                                    P.[nroPedido]
                            FROM[FranquiciaRestaurante].[dbo].[Pedido] P
                            WHERE P.[nroPedido] =" + id;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int nroPedido = (int)row[2];


                    if (pedidosMaterializados.Count() == 0) 
                    {
                        int cantComensales = (int)row[0];
                        DateTime fechaHoraPed = (DateTime)row[1];

                        pedido = nuevoPedido(cantComensales, fechaHoraPed, nroPedido);
                    }
                    else
                    {
                        bool existe = false;
                            foreach(Pedido ped in pedidosMaterializados) 
                            {
                                if (ped.getNroPedido() == nroPedido) 
                                {
                                    existe = true;
                                    pedido = ped;
                                    break;
                                }
                            }
                        if(!existe)
                        {
                            int cantComensales = (int)row[0];
                            DateTime fechaHoraPed = (DateTime)row[1];

                            pedido = nuevoPedido(cantComensales, fechaHoraPed, nroPedido);
                        }
                    }

                    return pedido;
                }
            }

            return null;
        }

        public List<Mesa> buscarMesa(int idPedido)
        {
            SqlConnection cn = new SqlConnection(conString);

            List<Mesa> mesas = new List<Mesa>();

            //primero debo buscar el numero de la mesa que voy a solicitar materializar
            string query = @"SELECT (CASE
		                                WHEN Mesa.[numero] IS NOT NULL THEN Mesa.numero
		                                WHEN Un.[IdUnionMesa] IS NOT NULL THEN UnMesa.IdMesa
	                                END) AS Mesas
                            FROM[FranquiciaRestaurante].[dbo].[Pedido] P
                            LEFT JOIN [FranquiciaRestaurante].[dbo].[Mesa] Mesa ON P.numeroMesa = Mesa.numero
                            LEFT JOIN [FranquiciaRestaurante].[dbo].[UnionMesa] Un ON P.unionMesa = Un.IdUnionMesa
                            LEFT JOIN [FranquiciaRestaurante].[dbo].[UnionMesa_Mesa] UnMesa ON Un.IdUnionMesa = UnMesa.IdUnionMesa
                            WHERE P.nroPedido = " + idPedido;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            int nroMesa=-1;

            using (cn) 
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) {
                    IDataRecord row = (IDataRecord)sqlDataReader;

                    nroMesa = (int)row[0];

                    mesas.Add((Mesa)persitenciaMesa.MaterializarPorId(nroMesa));
                }
            }

            return mesas;
        }

        public Pedido nuevoPedido(int cantComensales, DateTime fechaHora, int nroPedido) 
        {
            Pedido nuevo = new Pedido(cantComensales, fechaHora, nroPedido);
            // aregreo a las listas de pedidos ya materializados
            pedidosMaterializados.Add(nuevo);

            return nuevo;
        }
    }
}
