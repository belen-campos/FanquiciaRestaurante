using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Pedido
    {
        private int cntComensales { get; set; }
        private DetalleDePedido[] detPedido { get; set; }
        private DateTime fechaHoraPedido { get; set; }
        private HistorialEstado[] historialEstado { get; set; }
        private int nroPedido { get; set; }
    }
}
