﻿using CUFinalizarPreparacionPedido.soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class DetalleDePedido: IPersistencia, IComparable<DetalleDePedido>
    {
        private static PersistenciaBDDetallesDePedido Persistencia = new PersistenciaBDDetallesDePedido();
        private int nroPedido;
        private int nroDetalle;
        private int cantidad;
        private List<HistorialEstado> historialEstado;
        private TimeSpan hora;
        private Menu menu;
        private decimal precio;
        private ProductoDeCarta producto;
        private TimeSpan tiempo;


        public DetalleDePedido(int cantidad, TimeSpan hora, decimal precio) 
        {
            this.cantidad = cantidad;
            this.hora = hora;
            this.precio = precio;
        }

        public DetalleDePedido(int pedido, int detalle, int cantidad, TimeSpan hora, decimal precio, Menu menu, ProductoDeCarta producto)
        {
            this.nroPedido = pedido;
            this.nroDetalle = detalle;
            this.cantidad = cantidad;
            this.hora = hora;
            this.precio = precio;
            this.menu = menu;
            this.producto = producto;
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
            return this.nroPedido;
        }

        public int getNroDetalle()
        {
            return this.nroDetalle;
        }

        public TimeSpan getHora() { return this.hora; }

        public int getCantidad() { return this.cantidad; }

        public bool contieneMenu()
        {
            return this.menu != null;
        }

        public string mostrarNombreProducto() 
        {
            return this.producto.mostrarProducto();
        }

        public string mostrarNombreMenu() 
        {
            return this.menu.getNombre();
        }

        public string mostrarMesa() 
        {
            Pedido pedido = Persistencia.buscarPedido(this.nroPedido);
            return pedido.mostrarMesa();
        }

        //para poder ordenarlos por hora
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

        internal void finalizar(Estado listoParaServir, DateTime fechaHoraActual)
        {
            HistorialEstado ultimo = setearFinUltimoHistoria(fechaHoraActual);
            HistorialEstado nuevo = crearHistoria(listoParaServir, fechaHoraActual);
            Persistencia.cambiarEstado(this, ultimo, nuevo);
        }

        private HistorialEstado crearHistoria(Estado listoParaServir, DateTime fechaHoraActual)
        {
            HistorialEstado nuevo = new HistorialEstado(listoParaServir, fechaHoraActual, null);
            historialEstado.Add(nuevo);
            return nuevo;
        }

        private HistorialEstado setearFinUltimoHistoria(DateTime fechaHoraActual)
        {
            HistorialEstado ultimo = obtenerUltimoEstado();
            ultimo.setFechaHoraFin(fechaHoraActual);
            return ultimo;
        }

        internal void quitarHistorial(HistorialEstado nuevo)
        {
            int indice = historialEstado.IndexOf(nuevo);
            historialEstado[indice] = null;
        }
    }
}
