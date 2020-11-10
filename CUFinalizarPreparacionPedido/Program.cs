using CUFinalizarPreparacionPedido.interfaz;
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

            InterfazDispositivoMovil interfazMovil1 = new InterfazDispositivoMovil();
            InterfazDispositivoMovil interfazMovil2 = new InterfazDispositivoMovil();

            Application.Run(new interfaz.PantallaFinalizarPreparacionPedido());
        }
    }
}
