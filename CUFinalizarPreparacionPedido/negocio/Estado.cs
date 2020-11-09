using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Estado
    {
        private String ambito { get; set; }

        private String nombre { get; set; }
        public Estado(string ambito, string nombre) 
        {
            this.ambito = ambito;
            this.nombre = nombre;
        }

        public String getAmbito() { return this.ambito; }

        public String getNombre() { return this.nombre; }

        public bool esAmbitoDetallePedido()
        {
            return this.ambito == "DetallePedido";
        }

        public bool esEnPreparacion()
        {
            return this.nombre == "En preparacion";
        }
    }
}
