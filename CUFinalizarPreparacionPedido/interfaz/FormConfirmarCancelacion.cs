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
    public partial class FormConfirmarCancelacion : Form
    {
        PantallaFinalizarPreparacionPedido pantalla;
        public FormConfirmarCancelacion(PantallaFinalizarPreparacionPedido pantalla)
        {
            InitializeComponent();
            this.pantalla = pantalla;
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            pantalla.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
