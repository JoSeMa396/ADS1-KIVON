using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WFASistemaHeladeriaKivon
{
    class ClassManejadorUsuario
    {
        public int RegistrarUsuario(ClassUsuario objetoUsuario)
        {
            int exitoInsertarUsuario = 0; //si la consulta fallo por defecto el valor sera cero

            MySqlConnection conexion = ClassConexion.abrirConexion(); // abriendo la conexion de base de datos

            string sqlInsertarUsuario = "insert into usuario(idRol, idSucursal, ci, lugarExpedicion, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, numeroCelular, login, password, activo, fotografia) values(?idRol, ?idSucursal, ?ci, ?lugarExpedicion, ?primerNombre, ?segundoNombre, ?apellidoPaterno, ?apellidoMaterno, ?fechaNacimiento, ?numeroCelular, ?login, ?password, ?activo, ?fotografia);";

            MySqlCommand CmdinsertarUsuario = new MySqlCommand(sqlInsertarUsuario, conexion);

            CmdinsertarUsuario.Parameters.AddWithValue("?idRol", objetoUsuario.IdRol);
            CmdinsertarUsuario.Parameters.AddWithValue("?idSucursal", objetoUsuario.IdSucursal);
            CmdinsertarUsuario.Parameters.AddWithValue("?ci", objetoUsuario.Ci);
            CmdinsertarUsuario.Parameters.AddWithValue("?lugarExpedicion", objetoUsuario.LugarExpedicion);
            CmdinsertarUsuario.Parameters.AddWithValue("?primerNombre", objetoUsuario.PrimerNombre);
            CmdinsertarUsuario.Parameters.AddWithValue("?segundoNombre", objetoUsuario.SegundoNombre);
            CmdinsertarUsuario.Parameters.AddWithValue("?apellidoPaterno", objetoUsuario.ApellidoPaterno);
            CmdinsertarUsuario.Parameters.AddWithValue("?apellidoMaterno", objetoUsuario.ApellidoMaterno);
            CmdinsertarUsuario.Parameters.AddWithValue("?fechaNacimiento", objetoUsuario.FechaNacimiento);
            CmdinsertarUsuario.Parameters.AddWithValue("?numeroCelular", objetoUsuario.NumeroCelular);
            CmdinsertarUsuario.Parameters.AddWithValue("?login", objetoUsuario.Login);
            CmdinsertarUsuario.Parameters.AddWithValue("?password", objetoUsuario.Password);
            CmdinsertarUsuario.Parameters.AddWithValue("?activo", objetoUsuario.Activo);
            CmdinsertarUsuario.Parameters.AddWithValue("?fotografia", objetoUsuario.ImagenFotografia);

            exitoInsertarUsuario = CmdinsertarUsuario.ExecuteNonQuery();

            conexion.Close();

            return exitoInsertarUsuario;
        }
        //fin Registrar Usuario

        public List<ClassUsuario> listarUsuarios()
        {
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();

            MySqlConnection conexion = ClassConexion.abrirConexion();

            string sqlListaUsuarios = "SELECT * FROM usuario ORDER BY apellidoPaterno, apellidoMaterno,primerNombre,segundoNombre;";

            MySqlCommand cmdListaUsuarios = new MySqlCommand(sqlListaUsuarios, conexion);
            MySqlDataReader drLecturaDeConsulta = cmdListaUsuarios.ExecuteReader();

            while (drLecturaDeConsulta.Read())
            {
                ClassUsuario objUsuario = new ClassUsuario();

                objUsuario.IdPersona = drLecturaDeConsulta.GetInt32(0);
                objUsuario.IdRol = drLecturaDeConsulta.GetInt32(1);
                objUsuario.IdSucursal = drLecturaDeConsulta.GetInt32(2);
                objUsuario.PrimerNombre = drLecturaDeConsulta.GetString(3);
                objUsuario.SegundoNombre = drLecturaDeConsulta.GetString(4);
                objUsuario.ApellidoPaterno = drLecturaDeConsulta.GetString(5);
                objUsuario.ApellidoMaterno = drLecturaDeConsulta.GetString(6);
                objUsuario.Ci = drLecturaDeConsulta.GetString(7);
                objUsuario.LugarExpedicion = drLecturaDeConsulta.GetString(8);
                objUsuario.FechaNacimiento = (drLecturaDeConsulta.GetDateTime(9).Date).ToString();
                objUsuario.ImagenFotografia = drLecturaDeConsulta.GetString(10);
                objUsuario.NumeroCelular = drLecturaDeConsulta.GetInt32(11);
                objUsuario.Activo = drLecturaDeConsulta.GetBoolean(14);

                listaUsuarios.Add(objUsuario);
            }
            return listaUsuarios;
        }

        public string validarCi(string ci)
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();

            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "select idusuario as id from usuario where ci =?ci union select idcliente as id from cliente where ci=?ci union select idreferenciausuario  as id from referenciausuario where ci=?ci;";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?ci", ci);

            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                ClassUsuario u = new ClassUsuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                listaUsuarios.Add(u);
            }

            if (listaUsuarios.Count != 0)
            {
                campoRepetido = "Ci";
            }

            return campoRepetido;
        }
        // verifica que el CI dado no esté repetido en la base de datos

        public string validarCelular(string celular)
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE numeroCelular = ?celular";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?celular", celular);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                ClassUsuario u = new ClassUsuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            if (listaUsuarios.Count != 0)
            {
                campoRepetido = "Celular";
            }

            return campoRepetido;
        }
        // verifica que el numero de celular dado no esté repetido en la base de datos

        public string validarUsuario(string usuario)
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE login = ?usuario";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?usuario", usuario);
            MySqlDataReader lecturaConsulta = cmdValidar.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                ClassUsuario u = new ClassUsuario();
                u.IdPersona = lecturaConsulta.GetInt32(0);
                Console.WriteLine(u.IdPersona);
                listaUsuarios.Add(u);
            }

            if (listaUsuarios.Count != 0)
            {
                campoRepetido = "Nombre de usuario";
            }

            return campoRepetido;
        }
        // verifica que el nombre de usuario dado no esté repetido en la base de datos

        public List<string> verificarDatosRepetidos(string ci, string celular, string usuario)
        {
            List<string> repetidos = new List<string>();

            if (validarCi(ci) != null)
                repetidos.Add(validarCi(ci));
            if (validarCelular(celular) != null)
                repetidos.Add(validarCelular(celular));
            if (validarUsuario(usuario) != null)
                repetidos.Add(validarUsuario(usuario));

            return repetidos;
        }
        // verifica que todos los datos obligatorios a llenar en el formulario no estén repetidos en la base de datos
        //metodo pide un usuario
        public ClassUsuario pedirUsuario(int idUsuario)
        {
            ClassUsuario pedido = new ClassUsuario();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlPedido = "SELECT * FROM USUARIO WHERE idUsuario = ?idUsuario";
            MySqlCommand pedirUsuario = new MySqlCommand(sqlPedido, conexion);
            pedirUsuario.Parameters.AddWithValue("?idUsuario", idUsuario);
            MySqlDataReader lecturaConsulta = pedirUsuario.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                pedido.IdRol = lecturaConsulta.GetInt32(1);
                pedido.Ci = lecturaConsulta.GetString(3);
                pedido.LugarExpedicion = lecturaConsulta.GetString(4);
                pedido.PrimerNombre = lecturaConsulta.GetString(5);
                pedido.SegundoNombre = lecturaConsulta.GetString(6);
                pedido.ApellidoPaterno = lecturaConsulta.GetString(7);
                pedido.ApellidoMaterno = lecturaConsulta.GetString(8);
                pedido.FechaNacimiento = lecturaConsulta.GetString(9);
                pedido.NumeroCelular = lecturaConsulta.GetInt32(10);
                pedido.Login = lecturaConsulta.GetString(11);
                pedido.Password = lecturaConsulta.GetString(12);

            }
            return pedido;
        }
        //fin metodo pedir un usuario
        //metodo modificar usuario
        public int modificarUsuario(ClassUsuario obUsuario, int idUsuario)
        {
            int exitoModificar = 0;
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlModificar = "update usuario set idRol = ?idrol, ci = ?ci, primerNombre = ?primernombre, segundoNombre = ?segundonombre, apellidoPaterno = ?apellidopaterno, apellidoMaterno = ?apellidomaterno, fechaNacimiento = ?fechanacimiento, lugarExpedicion = ?lugarexpedicion, numeroCelular = ?numerocelular, login = ?login, password = ?password where idUsuario = ?idusuario;";
            MySqlCommand modificarUsuario = new MySqlCommand(sqlModificar, conexion);
            modificarUsuario.Parameters.AddWithValue("?idRol", obUsuario.IdRol);
            modificarUsuario.Parameters.AddWithValue("?ci", obUsuario.Ci);
            modificarUsuario.Parameters.AddWithValue("?primernombre", obUsuario.PrimerNombre);
            modificarUsuario.Parameters.AddWithValue("?segundonombre", obUsuario.SegundoNombre);
            modificarUsuario.Parameters.AddWithValue("?apellidopaterno", obUsuario.ApellidoPaterno);
            modificarUsuario.Parameters.AddWithValue("?apellidomaterno", obUsuario.ApellidoMaterno);
            modificarUsuario.Parameters.AddWithValue("?fechanacimiento", obUsuario.FechaNacimiento);
            modificarUsuario.Parameters.AddWithValue("?lugarexpedicion", obUsuario.LugarExpedicion);
            modificarUsuario.Parameters.AddWithValue("?numerocelular", obUsuario.NumeroCelular);
            modificarUsuario.Parameters.AddWithValue("?login", obUsuario.Login);
            modificarUsuario.Parameters.AddWithValue("?password", obUsuario.Password);
            modificarUsuario.Parameters.AddWithValue("?idusuario", idUsuario);

            try
            {
                exitoModificar = modificarUsuario.ExecuteNonQuery();
                Console.WriteLine("El valor retornado" + exitoModificar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta" + ex.Message);
            }
            conexion.Close();

            return exitoModificar;

        }
        //fin metodo modificar usuario
    }
}
