using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUFinalizarPreparacionPedido.negocio;

namespace CUFinalizarPreparacionPedido.interfaz
{
    public partial class InterfazDispositivoMovil : Form, IObservadorFinalizacionPreparacion
    {
        private static List<IObservadorFinalizacionPreparacion> interfacesMoviles = new List<IObservadorFinalizacionPreparacion>();
        public InterfazDispositivoMovil()
        {
            InitializeComponent();
            interfacesMoviles.Add(this);
        }

        public void visualizar(string numMesa, int cntProd)
        {
            
        }

        public static List<IObservadorFinalizacionPreparacion> CargarInterfaz() 
        {
            return interfacesMoviles;
        }
    }
}
