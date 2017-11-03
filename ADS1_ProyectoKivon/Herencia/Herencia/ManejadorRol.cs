using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class ManejadorRol
    {

        public List<Rol> listaRoles()
        {
            List<Rol> listaRol = new List<Rol>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlListaRoles = "SELECT idRol, nombreRol FROM rol ORDER BY nombreRol;";

            MySqlCommand cmdListaRoles = new MySqlCommand(sqlListaRoles, conexion);
            MySqlDataReader drLecturaDeConsulta = cmdListaRoles.ExecuteReader();

            while (drLecturaDeConsulta.Read())
            {
                Rol objRol = new Rol();
                objRol.idRol = drLecturaDeConsulta.GetInt32(0);
                objRol.nombreRol= drLecturaDeConsulta.GetString(1);

                listaRol.Add(objRol);
            }
            return listaRol;
        }//fin metodo

    }
}
