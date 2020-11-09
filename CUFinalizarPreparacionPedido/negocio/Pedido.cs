using CUFinalizarPreparacionPedido.soporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Pedido : IPersistencia
    {
        private static PersistenciaBDPedido Persistencia = new PersistenciaBDPedido();
        private int cntComensales { get; set; }
        private List<DetalleDePedido> detPedido { get; set; }
        private DateTime fechaHoraPedido { get; set; }
        private List<HistorialEstado> historialEstado { get; set; }
        private int nroPedido { get; set; }

        //private Factura factura

        public Pedido(int cntComensales, DateTime fechaHora, int nroPedido) 
        {
            this.cntComensales = cntComensales;
            this.fechaHoraPedido = fechaHora;
            this.nroPedido = nroPedido;
            this.detPedido = new List<DetalleDePedido>();
            this.historialEstado = new List<HistorialEstado>();
        }

        public int getNroPedido() { return this.nroPedido; }

        public string mostrarMesa() 
        {
            string mostrarMesas = null;
            List<Mesa> mesas = Persistencia.buscarMesa(this.nroPedido);
            foreach (Mesa item in mesas) 
            {
                if (mostrarMesas == null) mostrarMesas += item.mostrarNumero();
                else mostrarMesas +=  " - " + item.mostrarNumero();
            }
            return mostrarMesas;
        }
    }
}
