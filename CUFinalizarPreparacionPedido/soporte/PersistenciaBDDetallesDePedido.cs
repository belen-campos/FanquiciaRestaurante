using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CUFinalizarPreparacionPedido.soporte
{
    public class PersistenciaBDDetallesDePedido
    {
        private static PersistenciaBDPedido persitenciaPedido = new PersistenciaBDPedido();
        private static PersistenciaBDHistorialEstado persitenciaHistorialEstado = new PersistenciaBDHistorialEstado();

        private static string conString = "Server=DESKTOP-BJK4AIA;DataBase=FranquiciaRestaurante; Integrated Security=true;";

        public object MaterializarPorId(object id)
        {
            SqlConnection cn = new SqlConnection(conString);

            DetalleDePedido dp;

            string query = @"SELECT [nroDetallePedido],
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

                    dp = new DetalleDePedido(nroPedido, nroDetalle, cantidad, hora, precio, null, null);
                    
                    return dp;
                }
            }

            return null;
        }

        public List<DetalleDePedido> buscarTodosDetallesPedido()
        {
            SqlConnection cn = new SqlConnection(conString);

            List<DetalleDePedido> dp = new List<DetalleDePedido>();
            string query = @"SELECT DP.[nroPedido],
	                                DP.[nroDetallePedido],
                                    DP.[cantidad],
                                    DP.[hora],
                                    DP.[precio],
									Menu.[idMenu],
									Menu.[cantidadMinimaComensales],
									Menu.[fechaCreacion],
									Menu.[nombre],
									Menu.[precio],
									Carta.[idProductoDeCarta],
									Carta.[esFavorito],
									Carta.[precio],
									Prod.[idProducto],
									Prod.[fechaCreacion],
									Prod.[nombre],
									Prod.[precio]
                            FROM [FranquiciaRestaurante].[dbo].[DetalleDePedido] DP
							LEFT JOIN [FranquiciaRestaurante].[dbo].[Menu] Menu ON DP.idMenu = Menu.idMenu
							LEFT JOIN [FranquiciaRestaurante].[dbo].[ProductoDeCarta] Carta ON DP.idProducto = Carta.idProductoDeCarta
							LEFT JOIN [FranquiciaRestaurante].[dbo].[Producto] Prod ON Carta.idProducto = Prod.idProducto";

            SqlCommand sqlCommandEstados = new SqlCommand(query, cn);

            using (cn)
            {
                cn.Open();

                //Listas para evitar crear otro objeto de un mismo producto o carta
                List<int> idProductosCarta = new List<int>();
                List<ProductoDeCarta> prodcutosCarta = new List<ProductoDeCarta>();
                List<int> idProductos = new List<int>();
                List<Producto> prodcutos = new List<Producto>();
                List<int> idMenus = new List<int>();
                List<Menu> menus = new List<Menu>();

                SqlDataReader sqlDataReader = sqlCommandEstados.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    IDataRecord row = (IDataRecord)sqlDataReader;
                    //del detalla
                    int nroPedido = (int)row[0];
                    int nroDetalle = (int)row[1];
                    int cantidad = (int)row[2];
                    TimeSpan hora = (TimeSpan)row[3];
                    decimal precio = (decimal)row[4];

                    ProductoDeCarta prodCarta = null ;
                    Menu menu=null;

                    //del menu o producto
                    if (row.IsDBNull(5)) 
                    {
                        int idCarta = (int)row[10];

                        if (idProductosCarta.Contains(idCarta)) 
                        {
                            //si ya se creo busco su indice en la lista de id y lo busco en la lista de prodcutos carta
                            int indice = idProductosCarta.IndexOf(idCarta);
                            prodCarta = prodcutosCarta[indice];
                        }
                        else 
                        {
                            //guardo los atributos de la carta
                            bool esFavorito = (bool)row[11];
                            decimal precioCarta = (decimal)row[12];

                            Producto producto;

                            //verifico si el producto existe
                            int idProducto = (int)row[13];
                            if (idProductos.Contains(idProducto))
                            {
                                int indice = idProductos.IndexOf(idProducto);
                                producto = prodcutos[indice];
                            }
                            else 
                            {
                                DateTime fechaCreacionProd = (DateTime)row[14];
                                string nombreProd = (string)row[15];
                                decimal precioProd = (decimal)row[16];
                                producto = new Producto(fechaCreacionProd, nombreProd, precioProd);

                                //agrego el id y el producto a las listas
                                idProductos.Add(idProducto);
                                prodcutos.Add(producto);
                            }

                            prodCarta = new ProductoDeCarta(esFavorito, precioCarta, producto);
                            //agrego el id y el prodcuto de carta a las listas
                            idProductosCarta.Add(idCarta);
                            prodcutosCarta.Add(prodCarta);
                        }
                    }
                    else 
                    {
                        int idMenu = (int)row[5];

                        if (idMenus.Contains(idMenu))
                        {
                            //si ya se creo busco su indice en la lista de id y lo busco en la lista de prodcutos carta
                            int indice = idMenus.IndexOf(idMenu);
                            menu = menus[indice];
                        }
                        else 
                        {
                            int cantidadMinimaComensales = (int)row[6];
                            DateTime fechaCreacionMenu = (DateTime)row[7];
                            string nombreMenu= (string)row[8];
                            decimal precioMenu = (decimal)row[9];

                            menu = new Menu(cantidadMinimaComensales, fechaCreacionMenu, nombreMenu, precioMenu);
                            // aregreo a las listas de id y menus
                            idMenus.Add(idMenu);
                            menus.Add(menu);
                        }
                    }

                    dp.Add(new DetalleDePedido(nroPedido, nroDetalle, cantidad, hora, precio, menu, prodCarta));

                }

                sqlDataReader.Close();

                foreach(DetalleDePedido detalle in dp)
                {

                    List<HistorialEstado> historial = persitenciaHistorialEstado.getHisrotialDetallePedido(detalle.getNroPedido(), detalle.getNroDetalle(), cn);

                    detalle.setHistorialEstado(historial);

                    
                }
            }

            return dp;
        }

        public void cambiarEstado(DetalleDePedido detalleDePedido, HistorialEstado ultimo, HistorialEstado nuevo)
        {
            SqlConnection cn = new SqlConnection(conString);

            using (cn) 
            {
                cn.Open();
                using (var tran = cn.BeginTransaction()) 
                {
                    try 
                    {
                        setearUltimaHistoria(detalleDePedido, ultimo, tran);

                        persitenciaHistorialEstado.crearHistorial(detalleDePedido, nuevo, tran);

                        tran.Commit();
                    }
                    catch (Exception ex) 
                    {
                        tran.Rollback();
                        //elimino la fechahora del historial que vino como ultimo
                        ultimo.setFechaHoraFin(null);
                        //se saca del historial el que se habia agregado
                        detalleDePedido.quitarHistorial(nuevo);
                    }
                }
            }
        }

        public void setearUltimaHistoria(DetalleDePedido detalle, HistorialEstado ultimo, SqlTransaction tran)
        {
            //busco el id del historial para poder pasarlo a la persistencia del historial
            int idHistorial = -1;

            string query = @"SELECT HE.idHistorialEstado
                            FROM [FranquiciaRestaurante].[dbo].[DetalleDePedidoHistorialEstado] DP
                            JOIN [FranquiciaRestaurante].[dbo].[HistorialEstado] HE ON DP.idHistorialEstado = HE.idHistorialEstado
                            WHERE DP.nroPedido = "+detalle.getNroPedido()+
                                "AND DP.nroDetallePedido = "+detalle.getNroDetalle()+
                                "AND HE.fechaHoraFin IS NULL";

            SqlCommand sqlCommandIdHistorial = new SqlCommand(query, tran.Connection);
            sqlCommandIdHistorial.Transaction = tran;
            
            SqlDataReader sqlDataReader = sqlCommandIdHistorial.ExecuteReader();
            while (sqlDataReader.Read())
            {
                IDataRecord row = (IDataRecord)sqlDataReader;
                idHistorial = (int)row[0];
            }

            sqlDataReader.Close();

            persitenciaHistorialEstado.setearHistorialEstado(idHistorial, ultimo, tran);
        }

        public Pedido buscarPedido(int idPedido)
        {
            return (Pedido)persitenciaPedido.MaterializarPorId(idPedido);
        }
    }
}
