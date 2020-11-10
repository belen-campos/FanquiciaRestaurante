using CUFinalizarPreparacionPedido.soporte;
using interfaz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class GestorFinalizarPreparacionPedido
    {
        private PantallaFinalizarPreparacionPedido pantalla;
        private List<DetalleDePedido> detallesEnPreparacion;
        private DetalleDePedido[] detallesPedidosNotificados;
        private List<DetalleDePedido> detallesPedidoSeleccionadosAServir;
        private IGestorPersistencia persistencia;

        public GestorFinalizarPreparacionPedido(PantallaFinalizarPreparacionPedido pantalla)
        {
            this.pantalla = pantalla;
            detallesEnPreparacion = new List<DetalleDePedido>();
            detallesPedidoSeleccionadosAServir = new List<DetalleDePedido>();
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
            persistencia = new PersistenciaBDEstado();

            List<Estado> estadosTodos = persistencia.buscarTodosEstados();
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

            persistencia = new PersistenciaBDDetallesDePedido();
            List<DetalleDePedido> detallesTodos = persistencia.buscarTodosDetallesPedido(estadosTodos);

            foreach(DetalleDePedido dp in detallesTodos)
            {

                if (dp.getHistorialEstado().Count()>0) {
                    
                if (dp.estaEnPreparacion(estadoEnPreparacion)) this.detallesEnPreparacion.Add(dp);

                }
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

        public void detallePedidoSeleccionado(int indice) 
        {
            DetalleDePedido detalle = detallesEnPreparacion[indice];
            detallesPedidoSeleccionadosAServir.Add(detalle);
        }
    }
}
