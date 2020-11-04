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

namespace interfaz
{
    public partial class PantallaFinalizarPreparacionPedido : Form
    {
        private GestorFinalizarPreparacionPedido gestorFP;
        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
            gestorFP = new GestorFinalizarPreparacionPedido();
        }

        private void PantallaFinalizarPreparacionPedido_Load(object sender, EventArgs e)
        {
            gestorFP.finalizarPedido();
        }
    }
}
