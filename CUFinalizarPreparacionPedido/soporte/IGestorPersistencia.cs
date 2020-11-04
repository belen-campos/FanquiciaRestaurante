using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.soporte
{
    public interface IGestorPersistencia
    {
        public abstract Object MaterializarPorId(Object id);

        public abstract void DesMaterializar(Object obj);

        public abstract List<Estado> buscarTodosEstados();

        public abstract List<DetalleDePedido> buscarTodosDetallesPedido(List<Estado> estados);
    }
}
