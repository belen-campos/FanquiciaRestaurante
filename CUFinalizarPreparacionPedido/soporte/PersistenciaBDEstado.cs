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


        SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");
        public void DesMaterializar(object obj)
        {
            
        }

        public object MaterializarPorId(object id)
        {
            Estado es;

            String query = "SELECT * FROM dbo.Estado WHERE IdEstado =" + id;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int idEs = (int)row[0];
                    String nombre = (String)row[1];
                    String ambito = (String)row[2];
                    es = new Estado(idEs, ambito, nombre);

                    return es;
                }
            }

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
                    String ambito = (String)row[1];
                    String nombre = (String)row[2];
                    es.Add(new Estado(idEs, ambito, nombre));
                    i++;
                }
            }

            return es;
        }

        public List<DetalleDePedido> buscarTodosDetallesPedido(List<Estado> estados) { return null; }

    }
}
