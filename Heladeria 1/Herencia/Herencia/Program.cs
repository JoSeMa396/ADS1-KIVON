using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herencia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //static void Main(string[] args)
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IUUsuario());



            /*
             Usuario usuario = new Usuario();
             usuario.Ci = "12345";
             usuario.PrimerNombre = "Leonardo";
             usuario.SegundoNombre = "Carlos";
             usuario.ApellidoPaterno = "Suarez";
             usuario.ApellidoMaterno = "Cardozo";
             usuario.login = "lsuarez";
             usuario.numeroCelular = "60647852";

             Console.WriteLine("login:......" + usuario.login+"  numero celular:......."+usuario.numeroCelular);

             */
            /*
            Cliente cliente = new Cliente();
            cliente.Ci = "12345";
            cliente.PrimerNombre = "Leonardo";
            cliente.SegundoNombre = "Carlos";
            cliente.ApellidoPaterno = "Suarez";
            cliente.ApellidoMaterno = "Cardozo";
            cliente.nit = "123ABC";

            Console.WriteLine("CI:......"+cliente.Ci);
            */
            /*
            ReferenciaUsuario referenciaUsuario = new ReferenciaUsuario();
            referenciaUsuario.Ci = "70000000";
            referenciaUsuario.PrimerNombre = "Margarita";
            referenciaUsuario.ApellidoPaterno = "Villarroel";
            referenciaUsuario.numeroCelular = "1452789";

            Console.WriteLine("CI:......" + referenciaUsuario.Ci + " primer nombre "+referenciaUsuario.PrimerNombre);
            */
        }

    }
}
