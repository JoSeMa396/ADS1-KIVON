using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Heladeria_1
{
    class Conexion
    {
        public static MySqlConnection abrirConexion()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "kivon";
            MySqlConnection conexionbd = new MySqlConnection(builder.ToString());
            conexionbd.Open();
            return conexionbd;
        }
    }
}
