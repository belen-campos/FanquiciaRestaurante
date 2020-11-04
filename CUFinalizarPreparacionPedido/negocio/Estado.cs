using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Estado
    {
        private int idEstado { get; set; }

        private String ambito { get; set; }

        private String nombre { get; set; }

        public Estado() 
        { this.idEstado = -1; }
        public Estado(int idEstado, String ambito, String nombre) 
        {
            this.idEstado = idEstado;
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
            return this.nombre == "EnPreparacion";
        }
    }
}
