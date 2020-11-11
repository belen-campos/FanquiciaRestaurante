using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class ProductoDeCarta
    {
        private bool esFavorito { get; set; }
        private decimal precio { get; set; }
        private Producto producto { get; set; }

        public ProductoDeCarta(bool favorito, decimal precio, Producto producto) 
        {
            this.esFavorito = favorito;
            this.precio = precio;
            this.producto = producto;
        }

        public string mostrarProducto() 
        {
            return producto.getNombre();
        }
    }
}
