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

            string sqlListaUsuarios = "SELECT u.*, r.nombrerol FROM usuario u join rol r on u.idrol = r.idrol ORDER BY u.idusuario;";

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
                objUsuario.Login = drLecturaDeConsulta.GetString(12);
                objUsuario.Password = drLecturaDeConsulta.GetString(13);
                objUsuario.Activo = drLecturaDeConsulta.GetBoolean(14);
                objUsuario.NombreRol = drLecturaDeConsulta.GetString(15);

                listaUsuarios.Add(objUsuario);
            }
            return listaUsuarios;
        }

        public string validarCi(string ci, int idusuario = 0)//en el caso de que se quiera ingresar un nuevo usuario el id por default sera 0, en el caso de querer modificar los datos de un usuario se asignará el id de tal usuario
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();

            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "select idusuario from usuario where ci =?ci and idusuario != ?id union select idcliente from cliente where ci=?ci union select idreferenciausuario from referenciausuario where ci=?ci;";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?ci", ci);
            cmdValidar.Parameters.AddWithValue("?id", idusuario);

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
        }// verifica que el CI dado no esté repetido en la base de datos

        public string validarCelular(string celular, int idusuario = 0)
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE numeroCelular = ?celular and idusuario != ?id";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?celular", celular);
            cmdValidar.Parameters.AddWithValue("?id", idusuario);
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
        }// verifica que el numero de celular dado no esté repetido en la base de datos

        public string validarUsuario(string usuario, int idusuario = 0)
        {
            string campoRepetido = null;
            List<ClassUsuario> listaUsuarios = new List<ClassUsuario>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlValidarCampos = "SELECT idUsuario FROM usuario WHERE login = ?usuario and idusuario != ?id";
            MySqlCommand cmdValidar = new MySqlCommand(sqlValidarCampos, conexion);
            cmdValidar.Parameters.AddWithValue("?usuario", usuario);
            cmdValidar.Parameters.AddWithValue("?id", idusuario);
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
        }// verifica que el nombre de usuario dado no esté repetido en la base de datos

        public List<string> verificarDatosRepetidos(string ci, string celular, string usuario, int idusuario = 0)
        {
            List<string> repetidos = new List<string>();

            if (validarCi(ci, idusuario) != null)
                repetidos.Add(validarCi(ci));
            if (validarCelular(celular, idusuario) != null)
                repetidos.Add(validarCelular(celular));
            if (validarUsuario(usuario, idusuario) != null)
                repetidos.Add(validarUsuario(usuario));

            return repetidos;
        }// verifica que todos los datos obligatorios a llenar en el formulario no estén repetidos en la base de datos

        public ClassUsuario pedirUsuario(int idUsuario)
        {
            ClassUsuario Upedido = new ClassUsuario();
            MySqlConnection conexion = ClassConexion.abrirConexion();

            string sqlPedido = "SELECT * FROM USUARIO WHERE idUsuario = ?idUsuario";
            MySqlCommand pedirUsuario = new MySqlCommand(sqlPedido, conexion);
            pedirUsuario.Parameters.AddWithValue("?idUsuario", idUsuario);

            MySqlDataReader lecturaConsulta = pedirUsuario.ExecuteReader();

            while (lecturaConsulta.Read())
            {
                Upedido.IdPersona = lecturaConsulta.GetInt32(0);
                Upedido.IdRol = lecturaConsulta.GetInt32(1);
                Upedido.IdSucursal = lecturaConsulta.GetInt32(2);
                Upedido.PrimerNombre = lecturaConsulta.GetString(3);
                Upedido.SegundoNombre = lecturaConsulta.GetString(4);
                Upedido.ApellidoPaterno = lecturaConsulta.GetString(5);
                Upedido.ApellidoMaterno = lecturaConsulta.GetString(6);
                Upedido.Ci = lecturaConsulta.GetString(7);
                Upedido.LugarExpedicion = lecturaConsulta.GetString(8);
                Upedido.FechaNacimiento = (lecturaConsulta.GetDateTime(9).Date).ToString();
                Upedido.ImagenFotografia = lecturaConsulta.GetString(10);
                Upedido.NumeroCelular = lecturaConsulta.GetInt32(11);
                Upedido.Login = lecturaConsulta.GetString(12);
                Upedido.Password = lecturaConsulta.GetString(13);

            }
            return Upedido;
        }//busca un usuario de acuerdo a su id de usuario y en caso de encontrarlo devuelve tal usuario con todos sus datos

        public int modificarUsuario(ClassUsuario obUsuario, int idUsuario)
        {
            int exitoModificar = 0;
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlModificar = "update usuario set idRol = ?idrol, ci = ?ci, primerNombre = ?primernombre, segundoNombre = ?segundonombre, apellidoPaterno = ?apellidopaterno, apellidoMaterno = ?apellidomaterno, fechaNacimiento = ?fechanacimiento, lugarExpedicion = ?lugarexpedicion, numeroCelular = ?numerocelular, fotografia = ?fotografia, login = ?login, password = ?password, activo = ?activo where idUsuario = ?idusuario;";
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
            modificarUsuario.Parameters.AddWithValue("?fotografia", obUsuario.ImagenFotografia);
            modificarUsuario.Parameters.AddWithValue("?login", obUsuario.Login);
            modificarUsuario.Parameters.AddWithValue("?password", obUsuario.Password);
            modificarUsuario.Parameters.AddWithValue("?activo", obUsuario.Activo);
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

        }//modifica los datos de un usuario ya existente

        public ClassUsuario VerificarExistenciaUsuario(string NombreUsuario)
        {
            ClassUsuario encontrado = new ClassUsuario();
            MySqlConnection conexion = ClassConexion.abrirConexion();

            string sqlPedido = "select u.*, r.nombrerol from usuario u join rol r on u.idrol = r.idrol where u.login = ?login";
            MySqlCommand pedirUsuario = new MySqlCommand(sqlPedido, conexion);
            pedirUsuario.Parameters.AddWithValue("?login", NombreUsuario);

            MySqlDataReader lecturaConsulta = pedirUsuario.ExecuteReader();
            if (pedirUsuario != null)
            {
                while (lecturaConsulta.Read())
                {
                    encontrado.IdPersona = lecturaConsulta.GetInt32(0);
                    encontrado.IdRol = lecturaConsulta.GetInt32(1);
                    encontrado.IdSucursal = lecturaConsulta.GetInt32(2);
                    encontrado.PrimerNombre = lecturaConsulta.GetString(3);
                    encontrado.SegundoNombre = lecturaConsulta.GetString(4);
                    encontrado.ApellidoPaterno = lecturaConsulta.GetString(5);
                    encontrado.ApellidoMaterno = lecturaConsulta.GetString(6);
                    encontrado.Ci = lecturaConsulta.GetString(7);
                    encontrado.LugarExpedicion = lecturaConsulta.GetString(8);
                    encontrado.FechaNacimiento = (lecturaConsulta.GetDateTime(9).Date).ToString();
                    encontrado.ImagenFotografia = lecturaConsulta.GetString(10);
                    encontrado.NumeroCelular = lecturaConsulta.GetInt32(11);
                    encontrado.Login = lecturaConsulta.GetString(12);
                    encontrado.Password = lecturaConsulta.GetString(13);
                    encontrado.Activo = lecturaConsulta.GetBoolean(14);
                    encontrado.NombreRol = lecturaConsulta.GetString(15);

                }
            }
            return encontrado;
        }//busca un usuario de acuerdo a su nombre (login) de usuario y en caso de encontrarlo devuelve tal usuario con todos sus datos
    }
}
