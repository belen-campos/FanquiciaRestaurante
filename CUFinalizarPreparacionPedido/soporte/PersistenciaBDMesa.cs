﻿using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.soporte
{
    public class PersistenciaBDMesa : IGestorPersistencia
    {
        List<Mesa> mesasMaterializados = new List<Mesa>();

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
            Mesa mesa = null;

            SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=FranquiciaRestaurante; Integrated Security=true;");

            string query = @"SELECT Mesa.[numero],
	                                Mesa.[capacidadComensales],
                                    Mesa.[idEstado]
                            FROM[FranquiciaRestaurante].[dbo].[Mesa] Mesa
                            WHERE Mesa.[numero] =" + id;
            SqlCommand sqlCommand = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    int nroMesa = (int)row[0];

                    if(mesasMaterializados.Count()==0)
                    {
                        int idEstado = (int)row[2];
                        int cantComensales = (int)row[1];

                        mesa = nuevaMesa(nroMesa, idEstado, cantComensales);
                    }
                    else
                    {
                        bool existe = false;
                        foreach (Mesa item in mesasMaterializados)
                        {
                            if (item.mostrarNumero() == nroMesa)
                            {
                                existe = true;
                                mesa = item;
                                break;
                            }
                        }
                        if(!existe)
                        {
                            int idEstado = (int)row[2];
                            int cantComensales = (int)row[1];

                            mesa = nuevaMesa(nroMesa, idEstado, cantComensales);
                        }
                    }

                    return mesa;
                }
            }

            return null;
        }

        public Mesa nuevaMesa(int nroMesa, int idEstado, int cantComensales) 
        {
            //Busco el estado

            PersistenciaBDEstado estados = new PersistenciaBDEstado();
            Estado estadoMesa = estados.getEstado(idEstado);

            Mesa nueva = new Mesa(nroMesa, cantComensales, estadoMesa);
            // aregreo a las listas de mesas ya materializadas
            mesasMaterializados.Add(nueva);

            return nueva;
        }
    }
}