using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WFASistemaHeladeriaKivon
{
    class ClassConexion
    {
        public static MySqlConnection abrirConexion()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "kivon";

            MySqlConnection connexionBd = new MySqlConnection(builder.ToString());
            connexionBd.Open();
            return connexionBd;
        }
    }
}
