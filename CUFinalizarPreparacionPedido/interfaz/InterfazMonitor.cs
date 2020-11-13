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
        private string[][] infoPedidosParaServir;
        private static List<IObservadorFinalizacionPreparacion> interfacesMonitores = new List<IObservadorFinalizacionPreparacion>();
        public InterfazMonitor()
        {
            InitializeComponent();
            interfacesMonitores.Add(this);
            infoPedidosParaServir = new string[1][];
            for (int i = 0; i < infoPedidosParaServir.Length; i++)
            {
                infoPedidosParaServir[i] = new string[2];
            }
        }

        public void visualizar(string numMesa, int cntProd)
        {
            int indice = buscarMesa(numMesa);

            if (indice == -1)
            {
                //verifico que haya espacio en la matriz
                espacioEnMatriz();

                //agrego una fila
                var index = dgvMonitor.Rows.Add();
                dgvMonitor.Rows[index].Cells["mesa"].Value = numMesa;
                dgvMonitor.Rows[index].Cells["cantidad"].Value = cntProd;
                infoPedidosParaServir[index][0] = numMesa;
                infoPedidosParaServir[index][1] = Convert.ToString(cntProd);
            }
            else
            {
                //sumo a la mesa la cantidad nueva
                int cantidadActual = Convert.ToInt32(infoPedidosParaServir[indice][1]) + cntProd;
                dgvMonitor.Rows[indice].Cells["cantidad"].Value = cantidadActual;
                infoPedidosParaServir[indice][1] = Convert.ToString(cantidadActual);
            }

            dgvMonitor.ClearSelection();
        }

        private void espacioEnMatriz()
        {
            if (infoPedidosParaServir.Where(s => s != null).Count() == infoPedidosParaServir.Length)
            {
                //duplico el tamano del arreglo
                int tamanoNuevo = infoPedidosParaServir.Length * 2;
                string[][] aux = new string[tamanoNuevo][];
                for (int x = 0; x < aux.Length; x++)
                {
                    aux[x] = new string[2];
                }

                //copio los elementos que estaban antes
                int i = 0;
                foreach (string[] item in infoPedidosParaServir)
                {
                    aux[i] = item;
                    i++;
                }

                //asigno aux al arreglo del gestor
                infoPedidosParaServir = aux;
            }
        }

        private int buscarMesa(string numMesa)
        {
            //verifico que la mesa no este en la matriz ya
            for (int i = 0; i < infoPedidosParaServir.Length; i++)
            {
                if (infoPedidosParaServir[i][0] == numMesa)
                {
                    return i;
                }
            }
            return -1;
        }

        public static List<IObservadorFinalizacionPreparacion> CargarInterfaz()
        {
            return interfacesMonitores;
        }
    }
}
