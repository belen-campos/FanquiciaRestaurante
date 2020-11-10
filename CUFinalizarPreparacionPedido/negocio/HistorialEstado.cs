using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public class HistorialEstado
    {
        private Estado estado;
        private DateTime? fechaHoraFin;
        private DateTime fechaHoraInicio;

        public HistorialEstado(Estado e, DateTime fechaHoraInicio, DateTime? fechaHoraFin)
        {
            this.estado = e;
            this.fechaHoraInicio = fechaHoraInicio;
            if (fechaHoraFin != null) this.fechaHoraFin = fechaHoraFin;
        }

        public DateTime getFechaHoraInicio() { return (DateTime)this.fechaHoraInicio; }
        public DateTime getFechaHoraFin() { return (DateTime)this.fechaHoraFin; }
        public void setFechaHoraFin(DateTime? fechaHora) { fechaHoraFin = fechaHora; }
        public bool esUltimaHistoria()
        {
            return fechaHoraFin == null;
        }

        public bool esEnPreparacion()
        {
            return this.estado.esEnPreparacion();
        }

        public Estado getEstado() { return this.estado; }

    }
}
