using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Herencia
{
    class Conexion
    {
        public static MySqlConnection abrirConexion() {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "kivon";

            MySqlConnection connexionBd = new MySqlConnection(builder.ToString());
            connexionBd.Open();
            return connexionBd;

        }//end function

        /*
        public bool abrirConexion1()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "promocionbd66666666666666666666666666666";

            try
            {
                MySqlConnection connexionBd = new MySqlConnection(builder.ToString());

                MySqlCommand cmd = connexionBd.CreateCommand();
                cmd.CommandText = "insert into usuario(idRolUsuario,primerNombre,primerApellido,ci,usuario,password,estado) values(1, 'Marta', 'Heredia', '8956', 'mheredia', 'mheredia', 1)";
                connexionBd.Open();
                cmd.ExecuteNonQuery();

                //connexionBd.Open();
                //Console.WriteLine(connexionBd.ServerVersion);
                //return connexionBd;
                return true;
            }
            catch
            {
                return false;

            }
        }//end function
        */
    }//end Conexion
}//end namespace
