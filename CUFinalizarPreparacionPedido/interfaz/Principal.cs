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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnFinalizarPreparacionPedido_Click(object sender, EventArgs e)
        {
            PantallaFinalizarPreparacionPedido pantalla = new PantallaFinalizarPreparacionPedido();
            pantalla.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            foreach(Object item in InterfazDispositivoMovil.CargarInterfaz()) 
            {
                Form movil = (Form)item;
                movil.Show();
            }

            foreach (Object item in InterfazMonitor.CargarInterfaz())
            {
                Form monitor = (Form)item;
                monitor.Show();
            }
        }
    }
}
