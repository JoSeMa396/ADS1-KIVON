using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class ManejadorUsuario
    {

        public int RegistrarUsuario(Usuario objetoUsuario)
        {
            int exitoInsertarUsuario = 0; //si la consulta fallo por defecto el valor sera cero
            MySqlConnection conexion = Conexion.abrirConexion(); // abriendo la conexion de base de datos

            string sqlInsertarUsuario = "insert into usuario(idRol, idSucursal, ci, lugarExpedicion, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, numeroCelular, login, password, activo, fotografia) values(?idRol, ?idSucursal, ?ci, ?lugarExpedicion, ?primerNombre, ?segundoNombre, ?apellidoPaterno, ?apellidoMaterno, ?fechaNacimiento, ?numeroCelular, ?login, ?password, ?activo, ?fotografia);";

            MySqlCommand insertarUsuario = new MySqlCommand(sqlInsertarUsuario, conexion);

            insertarUsuario.Parameters.AddWithValue("?idRol", objetoUsuario.idRol);
            insertarUsuario.Parameters.AddWithValue("?idSucursal", objetoUsuario.idSucursal);
            insertarUsuario.Parameters.AddWithValue("?ci", objetoUsuario.Ci);
            insertarUsuario.Parameters.AddWithValue("?lugarExpedicion", objetoUsuario.lugarExpedicion);

            insertarUsuario.Parameters.AddWithValue("?primerNombre", objetoUsuario.PrimerNombre);
            insertarUsuario.Parameters.AddWithValue("?segundoNombre", objetoUsuario.SegundoNombre);

            insertarUsuario.Parameters.AddWithValue("?apellidoPaterno", objetoUsuario.ApellidoPaterno);
            insertarUsuario.Parameters.AddWithValue("?apellidoMaterno", objetoUsuario.ApellidoMaterno);

            insertarUsuario.Parameters.AddWithValue("?fechaNacimiento", objetoUsuario.fechaNacimiento);
            insertarUsuario.Parameters.AddWithValue("?numeroCelular", objetoUsuario.numeroCelular);
            insertarUsuario.Parameters.AddWithValue("?login", objetoUsuario.login);
            insertarUsuario.Parameters.AddWithValue("?password", objetoUsuario.password);
            insertarUsuario.Parameters.AddWithValue("?activo", objetoUsuario.activo);
            insertarUsuario.Parameters.AddWithValue("?fotografia", objetoUsuario.imagenFotografia);

            try
            {
                exitoInsertarUsuario = insertarUsuario.ExecuteNonQuery();
                Console.WriteLine("El valor retornado" + exitoInsertarUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta" + ex.Message);
            }
            conexion.Close();

            return exitoInsertarUsuario;
        }//fin Registrar Usuario


        public List<Usuario> listaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlListaUsuarios = "SELECT * FROM usuario ORDER BY apellidoPaterno, apellidoMaterno,primerNombre,segundoNombre;";

            MySqlCommand cmdListaUsuarios = new MySqlCommand(sqlListaUsuarios, conexion);
            MySqlDataReader drLecturaDeConsulta = cmdListaUsuarios.ExecuteReader();

            while (drLecturaDeConsulta.Read())
            {
                Usuario objUsuario = new Usuario();
                objUsuario.IdPersona = drLecturaDeConsulta.GetInt32(0);
                objUsuario.NombreCompleto = drLecturaDeConsulta.GetString(5) + " " + drLecturaDeConsulta.GetString(6) + " " + drLecturaDeConsulta.GetString(7) + " " + drLecturaDeConsulta.GetString(8);
                objUsuario.CiCompleto = drLecturaDeConsulta.GetString(3) + " " + drLecturaDeConsulta.GetString(4);
                objUsuario.fechaNacimiento = drLecturaDeConsulta.GetString(9);
                objUsuario.numeroCelular = drLecturaDeConsulta.GetInt32(10);
                objUsuario.ArgActivo = (drLecturaDeConsulta.GetBoolean(13)) == true ? "Activo" : "Inactivo";
                listaUsuarios.Add(objUsuario);
            }
            return listaUsuarios;
        }//fin metodo
        //metodos de validar
        public string validarCi(string ci)
        {
            string campoRepetido = null;
            List<Usuario> listaUsuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE ci = ?ci";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?ci", ci);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                Usuario u = new Usuario();
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

        public string validarFoto(string foto)
        {
            string campoRepetido = null;
            List<Usuario> listaUsuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE fotografia = ?foto";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?foto", foto);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                Usuario u = new Usuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            foreach (var item in listaUsuarios)
            {
                if (item.IdPersona != null)
                {
                    campoRepetido = "Fotografia";
                    break;
                }
            }

            return campoRepetido;
        }

        public string validarCelular(string celular)
        {
            string campoRepetido = null;
            List<Usuario> listaUsuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE numeroCelular = ?celular";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?celular", celular);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                Usuario u = new Usuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            foreach (var item in listaUsuarios)
            {
                if (item.IdPersona != null)
                {
                    campoRepetido = "Celular";
                    break;
                }
            }

            return campoRepetido;
        }

        public string validarUsuario(string usuario)
        {
            string campoRepetido = null;
            List<Usuario> listaUsuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE login = ?usuario";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?usuario", usuario);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                Usuario u = new Usuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            foreach (var item in listaUsuarios)
            {
                if (item.IdPersona != null)
                {
                    campoRepetido = "usuario";
                    break;
                }
            }

            return campoRepetido;
        }
        //fin metodo



    }
}
