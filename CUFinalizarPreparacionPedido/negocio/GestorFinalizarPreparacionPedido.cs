using CUFinalizarPreparacionPedido.interfaz;
using CUFinalizarPreparacionPedido.soporte;
using Dsi.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class GestorFinalizarPreparacionPedido: ISujetoFinalizacionPreparacion
    {
        private PantallaFinalizarPreparacionPedido pantalla;
        private List<DetalleDePedido> detallesEnPreparacion;
        private string[] detallesPedidosNotificados;
        private List<DetalleDePedido> detallesPedidoSeleccionadosAServir;
        private PersistenciaBDEstado persistenciaEstado;
        private PersistenciaBDDetallesDePedido persistenciaDetalle;
        private List<IObservadorFinalizacionPreparacion> observadores;

        public GestorFinalizarPreparacionPedido(PantallaFinalizarPreparacionPedido pantalla)
        {
            this.pantalla = pantalla;
            detallesEnPreparacion = new List<DetalleDePedido>();
            detallesPedidoSeleccionadosAServir = new List<DetalleDePedido>();
            observadores = new List<IObservadorFinalizacionPreparacion>();
            detallesPedidosNotificados = new string[1];
        }

        public void finalizarPedido()
        {
            string[] detalles = buscarDetallesPedidoEnPreparacion();
            pantalla.mostrarDatosDetallePedidoEnPreparacion(detalles);
            pantalla.solicitarSeleccionDeUnoVariosDetalles();
        }

        #region finalizarPedido
        private string[] buscarDetallesPedidoEnPreparacion()
        {
            persistenciaEstado = new PersistenciaBDEstado();

            List<Estado> estadosTodos = persistenciaEstado.buscarTodosEstados();
            Estado estadoEnPreparacion = null;

            foreach(Estado estado in estadosTodos)
            {
                if (estado.esAmbitoDetallePedido()) {
                    if (estado.esEnPreparacion())
                    {
                        estadoEnPreparacion = estado;
                        break;
                    }
                }
            }

            persistenciaDetalle = new PersistenciaBDDetallesDePedido();
            List<DetalleDePedido> detallesTodos = persistenciaDetalle.buscarTodosDetallesPedido();

            foreach(DetalleDePedido dp in detallesTodos)
            {
                if (dp.estaEnPreparacion(estadoEnPreparacion)) this.detallesEnPreparacion.Add(dp);
            }

            ordenarSegunMayorTiempoEspera();

            int cntDetalles = detallesEnPreparacion.Count();

            string[] detallesAMostrar = new string[cntDetalles];

            int i = 0;

            foreach (DetalleDePedido dp in detallesEnPreparacion) 
            {
                //dp.getHora();
                string nombreProductoMenu = buscarInfoDetallePedido(dp);
                int cantidad = dp.getCantidad();
                string mesa = buscarMesaDeDetalleEnPreparacion(dp);

                string detalle = nombreProductoMenu+'|'+cantidad+'|'+mesa;

                detallesAMostrar[i] = detalle;
                i++;
            }

            return detallesAMostrar;
        }

        private string buscarMesaDeDetalleEnPreparacion(DetalleDePedido dp)
        {
            return dp.mostrarMesa();
        }

        private string buscarInfoDetallePedido(DetalleDePedido dp)
        { 
            if (dp.contieneMenu()) return "-|"+dp.mostrarNombreMenu();
            else return dp.mostrarNombreProducto()+ "|-";
        }

        private void ordenarSegunMayorTiempoEspera()
        {
            this.detallesEnPreparacion.Sort(delegate (DetalleDePedido x, DetalleDePedido y)
                                             {
                                                if (x.getHora() == null && y.getHora() == null) return 0;
                                                else if (x.getHora() == null) return -1;
                                                else if (y.getHora() == null) return 1;
                                                else return x.CompareTo(y);
                                             });
        }
        #endregion

        public void detallePedidoSeleccionado(int indice, string mesa) 
        {
            DetalleDePedido detalle = detallesEnPreparacion[indice];
            detallesPedidoSeleccionadosAServir.Add(detalle);

            //cadena a notificar
            string notificar = mesa + '|' + detalle.getCantidad();
            //me aseguro que el arreglo para notificar no este lleno
            int indiceNot = detallesPedidosNotificados.Where(s => s != null).Count();
            if (detallesPedidosNotificados.Where(s =>s!=null).Count() == detallesPedidosNotificados.Length) 
            {
                //duplico el tamano del arreglo
                int tamanoNuevo = detallesPedidosNotificados.Length * 2;
                string[] aux = new string[tamanoNuevo];

                //copio los elementos que estaban antes
                int i = 0;
                foreach (string item in detallesPedidosNotificados)
                {
                    aux[i] = item;
                    i++;
                }

                //asigno aux al arreglo del gestor
                detallesPedidosNotificados = aux;
            }

            detallesPedidosNotificados[indiceNot] = notificar;
        }

        public void confirmacionElaboracion() 
        {
            actualizarEstadoDetallePedido();
        }

        private void actualizarEstadoDetallePedido()
        {
            List<Estado> estados = PersistenciaBDEstado.getTodosEstados();
            Estado listoParaServir = null;
            foreach(Estado estado in estados) 
            {
                if (estado.esAmbitoDetallePedido()) 
                {
                    if (estado.esListoParaServir())
                    {
                        listoParaServir = estado;
                        break;
                    }
                }
            }

            List<IObservadorFinalizacionPreparacion> obs = InterfazDispositivoMovil.CargarInterfaz();

            obs = obs.Concat(InterfazMonitor.CargarInterfaz()).ToList();

            for (int i = 0; i< detallesPedidoSeleccionadosAServir.Count(); i++) 
            {
                DetalleDePedido detalle = detallesPedidoSeleccionadosAServir[i];
                detalle.finalizar(listoParaServir, DateTime.Now);
                suscribir(obs);
                string[] aux = detallesPedidosNotificados[i].Split('|');
                string mesa = aux[0];
                var cantidad = aux[1];
                publicarDetPedidoAServir(mesa, Convert.ToInt32(cantidad));
                actualizarEstadoDetallePedido(detalle);
            }

            finCU();
        }

        private void finCU()
        {
            FormConfirmacion fin = new FormConfirmacion(pantalla);
            fin.ShowDialog();
        }

        private void actualizarEstadoDetallePedido(DetalleDePedido detalle)
        {
            List<Estado> estados = PersistenciaBDEstado.getTodosEstados();
            Estado notificado = null;
            foreach (Estado estado in estados)
            {
                if (estado.esAmbitoDetallePedido())
                {
                    if (estado.esNotificado())
                    {
                        notificado = estado;
                        break;
                    }
                }
            }

            detalle.notificar(notificado, DateTime.Now);
        }

        public void publicarDetPedidoAServir(string mesa, int cantidad)
        {
            foreach(IObservadorFinalizacionPreparacion o in observadores) 
            {
                o.visualizar(mesa, cantidad);
            }
        }

        public void suscribir(List<IObservadorFinalizacionPreparacion> obs)
        {
            foreach (IObservadorFinalizacionPreparacion o in obs) 
            {
                observadores.Add(o);   
            }
        }

        public void quitar(List<IObservadorFinalizacionPreparacion> obs)
        {
            foreach (IObservadorFinalizacionPreparacion o in obs)
            {
                int indice = observadores.IndexOf(o);
                observadores[indice]=null;
            }
        }
    }
}
