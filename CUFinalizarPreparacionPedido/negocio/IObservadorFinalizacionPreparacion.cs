using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    public interface IObservadorFinalizacionPreparacion
    {
        public void visualizar(string numMesas, int cntProd);
    }
}
