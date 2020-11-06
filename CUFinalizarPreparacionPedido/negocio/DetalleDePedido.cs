using CUFinalizarPreparacionPedido.soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class DetalleDePedido: IPersistencia, IComparable<DetalleDePedido>
    {
        private static int nroPedido;
        private static int nroDetalle;
        private int cantidad;
        private List<HistorialEstado> historialEstado;
        private TimeSpan hora;
        private Menu menu;
        private decimal precio;
        private Producto producto;
        private TimeSpan tiempo;


        public DetalleDePedido(int cantidad, TimeSpan hora, decimal precio) 
        {
            this.cantidad = cantidad;
            this.hora = hora;
            this.precio = precio;
        }

        public DetalleDePedido(int pedido, int detalle, int cantidad, TimeSpan hora, decimal precio)
        {
            nroPedido = pedido;
            nroDetalle = detalle;
            this.cantidad = cantidad;
            this.hora = hora;
            this.precio = precio;
        }

        public bool estaEnPreparacion(Estado es)
        {
            HistorialEstado ultimoHistorialEstado = obtenerUltimoEstado();
            return ultimoHistorialEstado.getEstado() == es;
        }

        public HistorialEstado obtenerUltimoEstado()
        {
            foreach(HistorialEstado he in historialEstado)
            {
                if (he.esUltimaHistoria()) {return he;}
            }
            return null;
        }

        internal void setHistorialEstado(List<HistorialEstado> historiales)
        {
            this.historialEstado = historiales;
        }

        public int getNroPedido()
        {
            return nroPedido;
        }

        public int getNroDetalle()
        {
            return nroDetalle;
        }

        public TimeSpan getHora() { return this.hora; }

        public int CompareTo(DetalleDePedido dp)
        {
            if (dp.getHora() > hora)
            {
                return -1;
            }
            else if (dp.getHora() == hora)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
