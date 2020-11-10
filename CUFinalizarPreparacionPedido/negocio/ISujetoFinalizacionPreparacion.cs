using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUFinalizarPreparacionPedido.negocio
{
    interface ISujetoFinalizacionPreparacion
    {
        //en este caso no se permite crear atributos en la interface

        public void publicarDetPedidoAServir();
        public void suscribir(List<IObservadorFinalizacionPreparacion> obs);
        public void quitar(List<IObservadorFinalizacionPreparacion> obs);
    }
}
