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

        //abrir ventana
        private void PantallaFinalizarPreparacionPedido_Load(object sender, EventArgs e)
        {
            gestorFP.finalizarPedido();
        }

        public void mostrarDatosDetallePedidoEnPreparacion(string[] detallesAMostrar) 
        {
            //llenar la grilla con estas cadenas, donde las columnas estan diferenciadas por ';'
            //el ';' se puede cambiar por otro caracter si hiciera falta
        }

        public void solicitarSeleccionDeUnoVariosDetalles() 
        {
            //que muestre en la pantalla o en algun lugar que seleccione alguno/s
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            //buscar la forma de pasarle al gestor cada uno de los indices/posiciones de los detalles seleccionados
            //se deben pasar de a uno al gestor: gestorFP.detallePedidoSeleccionado(indice)
            //Y por ulimo que aparezca el cartel de confirmacion
        }
    }
}
