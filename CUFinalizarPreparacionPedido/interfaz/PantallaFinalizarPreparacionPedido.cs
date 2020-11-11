using CUFinalizarPreparacionPedido.negocio;
using Dsi.Interfaz;
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

        string[] detallesAMostrar;
        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
            gestorFP = new GestorFinalizarPreparacionPedido(this);
            dvgDetallesTiempo.AutoGenerateColumns = false;
            foreach (DataGridViewColumn column in dvgDetallesTiempo.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dgvMesa.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            cmbMesa.Items.Add("Todos");
        }

        //abrir ventana
        private void PantallaFinalizarPreparacionPedido_Load(object sender, EventArgs e)
        {
            gestorFP.finalizarPedido();
        }

        public void mostrarDatosDetallePedidoEnPreparacion(string[] detalles) 
        {

            this.detallesAMostrar = detalles;
            for(int i=0; i<detallesAMostrar.Length; i++) 
            {
                string[] aux = detallesAMostrar[i].Split('|');
                string producto = aux[0];
                string menu = aux[1];
                string cantidad = aux[2];
                string mesa = aux[3];
                dvgDetallesTiempo.Rows.Insert(i, producto, menu, cantidad, mesa);
                dgvMesa.Rows.Insert(i, i, mesa, producto, menu, cantidad);
                if (!cmbMesa.Items.Contains(mesa))
                {
                    cmbMesa.Items.Add(mesa);
                }
            }
            dvgDetallesTiempo.ClearSelection();
            dgvMesa.Sort(dgvMesa.Columns["mesas"], ListSortDirection.Ascending);
            cmbMesa.SelectedItem = "Todos";
            dgvMesa.ClearSelection();
        }

        public void solicitarSeleccionDeUnoVariosDetalles() 
        {
            //que muestre en la pantalla o en algun lugar que seleccione alguno/s
        }

        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {

            if (opciones.SelectedTab == tabMesa) confirmarDetallesMesa();

            if (opciones.SelectedTab == tabTiempo) confirmarDetallesTiempo();
        }

        private void confirmarDetallesMesa()
        {
            if (dgvMesa.SelectedRows.Count == 0)
            {
                FormError error = new FormError();
                error.ShowDialog();
            }
            else
            {
                foreach (DataGridViewRow row in dgvMesa.SelectedRows)
                {
                    int indice = (int)row.Cells["IndiceOrig"].Value;
                    string mesa = (string)row.Cells["mesas"].Value;

                    gestorFP.detallePedidoSeleccionado(indice, mesa);
                }

                MessageBox.Show("¿Seguro desea confirmar los cambios?", "Finalizacion detalles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                gestorFP.confirmacionElaboracion();
            }
        }

        private void confirmarDetallesTiempo()
        {
            if (dvgDetallesTiempo.SelectedRows.Count == 0)
            {
                FormError error = new FormError();
                error.ShowDialog();
            }
            else
            {
                foreach (DataGridViewRow row in dvgDetallesTiempo.SelectedRows)
                {
                    int indice = row.Index;
                    string mesa = (string)row.Cells["mesa"].Value;

                    gestorFP.detallePedidoSeleccionado(indice, mesa);
                }

                MessageBox.Show("¿Seguro desea confirmar los cambios?", "Finalizacion detalles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                gestorFP.confirmacionElaboracion();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormConfirmarCancelacion cancelar = new FormConfirmarCancelacion(this);
            cancelar.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMesa.ClearSelection();
            string selec = (string)cmbMesa.SelectedItem;

            foreach (DataGridViewRow row in dgvMesa.Rows) 
            {
                if (selec != "Todos")
                {
                    if ((string)row.Cells["mesas"].Value == selec) { row.Visible = true; }
                    else { row.Visible = false; }
                }
                else 
                {
                    row.Visible = true;
                }
            }

            dgvMesa.Sort(dgvMesa.Columns["mesas"], ListSortDirection.Ascending);
        }


        private void opciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMesa.ClearSelection();
            dvgDetallesTiempo.ClearSelection();
        }
    }
}
