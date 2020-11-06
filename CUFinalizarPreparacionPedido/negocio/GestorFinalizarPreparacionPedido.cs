using CUFinalizarPreparacionPedido.soporte;
using System.Collections.Generic;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class GestorFinalizarPreparacionPedido
    {
        private DetalleDePedido[] detallesPedidosNotificados;
        private DetalleDePedido[] detallesPedidoSeleccionadosAServir;
        private IGestorPersistencia persistencia;

        public List<DetalleDePedido> finalizarPedido()
        {
            return buscarDetallesPedidoEnPreparacion();
        }

        private List<DetalleDePedido> buscarDetallesPedidoEnPreparacion()
        {
            persistencia = new PersistenciaBDEstado();

            List<Estado> estadosTodos = persistencia.buscarTodosEstados();
            Estado estadoEnPreparacion = new Estado();

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

            List<DetalleDePedido> detallesEnPreparacion = new List<DetalleDePedido>();

            foreach(DetalleDePedido dp in detallesTodos)
            {
                if (dp.estaEnPreparacion(estadoEnPreparacion)) detallesEnPreparacion.Add(dp);
            }

            return ordenarSegunMayorTiempoEspera(detallesEnPreparacion);
        }

        private List<DetalleDePedido> ordenarSegunMayorTiempoEspera(List<DetalleDePedido> detallesEnPreparacion)
        {
            detallesEnPreparacion.Sort(delegate (DetalleDePedido x, DetalleDePedido y)
                                             {
                                                if (x.getHora() == null && y.getHora() == null) return 0;
                                                else if (x.getHora() == null) return -1;
                                                else if (y.getHora() == null) return 1;
                                                else return x.CompareTo(y);
                                             });
            return detallesEnPreparacion;
        }
    }
}
