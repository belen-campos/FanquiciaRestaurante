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

namespace CUFinalizarPreparacionPedido.interfaz
{
    public partial class PantallaFinalizarPreparacionPedido : Form
    {
        private GestorFinalizarPreparacionPedido gestorFP;
        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
            gestorFP = new GestorFinalizarPreparacionPedido(this);
            dvgDetallesEnPreparacion.AutoGenerateColumns = false;
            foreach (DataGridViewColumn column in dvgDetallesEnPreparacion.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //abrir ventana
        private void PantallaFinalizarPreparacionPedido_Load(object sender, EventArgs e)
        {
            gestorFP.finalizarPedido();
        }

        public void mostrarDatosDetallePedidoEnPreparacion(string[] detallesAMostrar) 
        {
            for(int i=0; i<detallesAMostrar.Length; i++) 
            {
                string[] aux = detallesAMostrar[i].Split('|');
                dvgDetallesEnPreparacion.Rows.Insert(i, aux[0], aux[1], aux[2], aux[3]);
            }
            dvgDetallesEnPreparacion.ClearSelection();
        }

        public void solicitarSeleccionDeUnoVariosDetalles() 
        {
            //que muestre en la pantalla o en algun lugar que seleccione alguno/s
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            //buscar la forma de pasarle al gestor cada uno de los indices/posiciones de los detalles seleccionados y la mesa porque esta cadena no se guarda
            //se deben pasar de a uno al gestor: gestorFP.detallePedidoSeleccionado(indice, mesa)
            //Y por ulimo que aparezca el cartel de confirmacion

            foreach (DataGridViewRow row in dvgDetallesEnPreparacion.SelectedRows)
            {
                int indice = row.Index;
                string mesa = (string)row.Cells["mesa"].Value;

                gestorFP.detallePedidoSeleccionado(indice, mesa);
            }

            gestorFP.confirmacionElaboracion();

        }
    }
}
