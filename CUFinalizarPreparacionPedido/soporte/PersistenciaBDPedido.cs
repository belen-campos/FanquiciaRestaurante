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
    public class PersistenciaBDPedido : IGestorPersistencia
    {
        private static PersistenciaBDMesa persitenciaMesa = new PersistenciaBDMesa();

        List<Pedido> pedidosMaterializados = new List<Pedido>();

        
        public List<DetalleDePedido> buscarTodosDetallesPedido(List<Estado> estados)
        {
            return null;
        }

        public List<Estado> buscarTodosEstados()
        {
            return null;
        }

        public void DesMaterializar(object obj)
        {
            throw new NotImplementedException();
        }

        public object MaterializarPorId(object id)
        {
            Pedido pedido=null;

            SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");


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

        public Mesa buscarMesa(int idPedido)
        {
            SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");

            //primero debo buscar el numero de la mesa que voy a solicitar materializar
            string query = @"SELECT P.[numeroMesa]
                            FROM[FranquiciaRestaurante].[dbo].[Pedido] P
                            WHERE P.[nroPedido] =" + idPedido;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            int nroMesa=-1;

            using (cn) 
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) {
                    IDataRecord row = (IDataRecord)sqlDataReader;

                    nroMesa = (int)row[0];
                }
            }

            return (Mesa)persitenciaMesa.MaterializarPorId(nroMesa);
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
