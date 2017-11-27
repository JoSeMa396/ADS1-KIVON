using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASistemaHeladeriaKivon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //static void Main(string[] args)
        //{
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IUPrincipal());

            //===============================================================================================================================================

            //ClassManejadorUsuario c = new ClassManejadorUsuario();
            //List<string> d = c.verificarDatosRepetidos("14478528", "/ fotos_garante / 7", "71736543", "drica");

            //if (d.Count != 0)
            //{
            //    foreach (var item in d)
            //    {
            //        Console.Write("\n" + item + "\n");
            //    }
            //}
            //else
            //{
            //    Console.Write("\nvacio\n");
            //}
        }
    }
}
