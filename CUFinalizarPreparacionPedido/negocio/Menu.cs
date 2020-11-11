using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class Menu
    {
        private int cantidadMinimaComensales { get; set; }
        private string? comentarios { get; set; }
        private DateTime fechaCreacion { get; set; }
        private DateTime? fechaVigencia { get; set; }
        private string? foto { get; set; }
        private string nombre { get; set; }
        private decimal precio { get; set; }

        //private detallesmenu
        public Menu(int cntCom, DateTime fecha, string nom, decimal prec) 
        {
            this.cantidadMinimaComensales = cntCom;
            this.fechaCreacion = fecha;
            this.nombre = nom;
            this.precio = prec;
        }

        public string getNombre() { return this.nombre; }
    }
}
