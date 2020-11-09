using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Producto
    {
        private DateTime fechaCreacion { get; set; }
        private string? foto { get; set; }
        private string nombre { get; set; }
        private decimal precio { get; set; }

        //private SectoComanda sectorComanda { get; set; }

        private TimeSpan tiempoPres { get; set; }

        public Producto(DateTime fecha, string nombre, decimal precio) 
        {
            this.fechaCreacion = fecha;
            this.nombre = nombre;
            this.precio = precio;
        }

        public string getNombre() 
        {
            return this.nombre;
        }
    }
}
