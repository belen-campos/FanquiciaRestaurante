using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using CUFinalizarPreparacionPedido.negocio;
using System.Collections;

namespace CUFinalizarPreparacionPedido.soporte
{
    public class PersistenciaBDEstado : IGestorPersistencia
    {
        protected static List<int> idEstadosMaterializados = new List<int>();
        protected static List<Estado> estadosMaterializados = new List<Estado>();

        SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");
        public void DesMaterializar(object obj)
        {
            
        }

        public object MaterializarPorId(object id)
        {
            return null;
        }

        public List<Estado> buscarTodosEstados()
        {
            List<Estado> es = new List<Estado>();
            String query = "SELECT * FROM dbo.Estado";

            SqlCommand sqlCommandEstados = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommandEstados.ExecuteReader();

                int i = 0;
                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int idEs = (int)row[0];

                    Estado nuevo;

                    if (idEstadosMaterializados.Contains(idEs))
                    {
                        //si ya se creo busco su indice en la lista de id y lo busco en la lista de prodcutos carta
                        int indice = idEstadosMaterializados.IndexOf(idEs);
                        nuevo = estadosMaterializados[indice];
                    }
                    else
                    {
                        string ambito = (String)row[1];
                        string nombre = (String)row[2];

                        nuevo = new Estado(ambito, nombre);
                        // aregreo a las listas de id y estados
                        idEstadosMaterializados.Add(idEs);
                        estadosMaterializados.Add(nuevo);
                    }

                    es.Add(nuevo);
                    i++;
                }
            }

            return es;
        }

        public List<DetalleDePedido> buscarTodosDetallesPedido(List<Estado> estados) { return null; }

        public Estado getEstado(int id) 
        {
            if (idEstadosMaterializados.Contains(id))
            {
                //si ya se creo busco su indice en la lista de id y lo busco en la lista de prodcutos carta
                int indice = idEstadosMaterializados.IndexOf(id);
                return estadosMaterializados[indice];
            }

            return null;
        }

    }
}
