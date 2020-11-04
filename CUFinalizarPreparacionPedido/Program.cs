using System;
using System.Windows.Forms;

namespace CUFinalizarPreparacionPedido
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new interfaz.PantallaFinalizarPreparacionPedido());
        }
    }
}
