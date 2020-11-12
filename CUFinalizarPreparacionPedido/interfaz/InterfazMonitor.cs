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
        private static List<IObservadorFinalizacionPreparacion> interfacesMonitores = new List<IObservadorFinalizacionPreparacion>();
        public InterfazMonitor()
        {
            InitializeComponent();
            interfacesMonitores.Add(this);
        }

        public void visualizar(string numMesa, int cntProd)
        {
            var index = dgvMonitor.Rows.Add();
            dgvMonitor.Rows[index].Cells["mesa"].Value = numMesa;
            dgvMonitor.Rows[index].Cells["cantidad"].Value = cntProd;        }

            public static List<IObservadorFinalizacionPreparacion> CargarInterfaz()
        {
            return interfacesMonitores;
        }
    }
}
