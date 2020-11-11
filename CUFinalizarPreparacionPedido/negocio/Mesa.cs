using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Mesa
    {
        private int numero { get; set; }
        private int capacidadComensales { get; set; }
        private Estado estado { get; set; }
        private List<Pedido> pedidos { get; set; }
        private int? filaEnPlano { get; set; }
        private int? ordenEnPlano { get; set; }
        private string? forma { get; set; }
        private string? espacioQueOcupa { get; set; }

        public Mesa(int numero, int capacidadComensales, Estado estado) 
        {
            this.numero = numero;
            this.capacidadComensales = capacidadComensales;
            this.estado = estado;
            this.pedidos = new List<Pedido>();
        }

        public int mostrarNumero() 
        {
            return this.numero;
        }
    }
}
