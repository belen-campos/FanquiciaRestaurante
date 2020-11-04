using CUFinalizarPreparacionPedido.soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //ordenarSegunMayorTiempoEspera(detallesEnPreparacion);
            return null;
        }

        /*private List<DetalleDePedido> ordenarSegunMayorTiempoEspera(List<DetalleDePedido> detallesEnPreparacion)
        {
            // ver
            return (List<DetalleDePedido>)detallesEnPreparacion.OrderBy(d=>d.getHora());
        }*/
    }
}
