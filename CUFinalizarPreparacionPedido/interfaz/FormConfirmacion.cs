using CUFinalizarPreparacionPedido.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dsi.Interfaz
{
    public partial class FormConfirmacion : Form
    {
        PantallaFinalizarPreparacionPedido pantalla;
        public FormConfirmacion(PantallaFinalizarPreparacionPedido pantalla)
        {
            InitializeComponent();
            this.pantalla = pantalla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pantalla.Close();
        }
    }
}
