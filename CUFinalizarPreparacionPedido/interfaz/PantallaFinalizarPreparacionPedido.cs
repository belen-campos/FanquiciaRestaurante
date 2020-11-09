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
using System.Windows.Forms.VisualStyles;

namespace interfaz
{
    public partial class PantallaFinalizarPreparacionPedido : Form
    {
        private GestorFinalizarPreparacionPedido gestorFP;
        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
            gestorFP = new GestorFinalizarPreparacionPedido(this);
        }

        private void PantallaFinalizarPreparacionPedido_Load(object sender, EventArgs e)
        {
            gestorFP.finalizarPedido();
        }

        public void mostrarDatosDetallePedidoEnPreparacion(string[] detallesAMostrar) { }

        public void solicitarSeleccionDeUnoVariosDetalles() { }
    }
}
