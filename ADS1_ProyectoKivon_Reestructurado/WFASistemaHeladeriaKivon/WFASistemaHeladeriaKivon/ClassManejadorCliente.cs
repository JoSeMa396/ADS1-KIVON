using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WFASistemaHeladeriaKivon
{
    class ClassManejadorCliente
    {
        public int RegistrarCliente(ClassCliente objetoCliente)
        {
            int exitoInsertarCliente = 0; //si la consulta fallo por defecto el valor sera cero
            MySqlConnection conexion = ClassConexion.abrirConexion(); // abriendo la conexion de base de datos
            string sqlInsertarUsuario = "insert into cliente(idSucursal, ci, lugarExpedicion, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno) values(?idSucursal, ?ci, ?lugarExpedicion, ?primerNombre, ?segundoNombre, ?apellidoPaterno, ?apellidoMaterno);";
            MySqlCommand insertarCliente = new MySqlCommand(sqlInsertarUsuario, conexion);

            insertarCliente.Parameters.AddWithValue("?idSucursal", objetoCliente.IdSucursal);
            insertarCliente.Parameters.AddWithValue("?ci", objetoCliente.Ci);
            insertarCliente.Parameters.AddWithValue("?lugarExpedicion", objetoCliente.LugarExpedicion);
            insertarCliente.Parameters.AddWithValue("?primerNombre", objetoCliente.PrimerNombre);
            insertarCliente.Parameters.AddWithValue("?segundoNombre", objetoCliente.SegundoNombre);
            insertarCliente.Parameters.AddWithValue("?apellidoPaterno", objetoCliente.ApellidoPaterno);
            insertarCliente.Parameters.AddWithValue("?apellidoMaterno", objetoCliente.ApellidoMaterno);

            try
            {
                exitoInsertarCliente = insertarCliente.ExecuteNonQuery();
                Console.WriteLine("El valor retornado" + exitoInsertarCliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta" + ex.Message);
            }
            conexion.Close();

            return exitoInsertarCliente;
        }//fin Registrar Usuario
        public string validarCi(string ci)
        {
            string campoRepetido = null;
            List<ClassCliente> listaUsuarios = new List<ClassCliente>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "select idusuario as id from usuario where ci =?ci union select idcliente as id from cliente where ci=?ci union select idreferenciausuario  as id from referenciausuario where ci=?ci;";
            //string sqlValidarCampos1 = "SELECT idReferenciaUsuario FROM referenciausuario WHERE ci = ?ci";
            //string sqlValidarCampos2 = "SELECT idCliente FROM cliente WHERE ci = ?ci";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?ci", ci);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                ClassCliente u = new ClassCliente();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            foreach (var item in listaUsuarios)
            {
                if (item.IdPersona != null)
                {
                    campoRepetido = "CI";
                    break;
                }
            }

            return campoRepetido;
        }
    }
}
