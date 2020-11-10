using CUFinalizarPreparacionPedido.negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUFinalizarPreparacionPedido.interfaz
{
    public partial class InterfazMonitor : Form, IObservadorFinalizacionPreparacion
    {
        public InterfazMonitor()
        {
            InitializeComponent();
        }

        public void actualizar(int numMesa, int cntProd)
        {
            throw new NotImplementedException();
        }
    }
}
