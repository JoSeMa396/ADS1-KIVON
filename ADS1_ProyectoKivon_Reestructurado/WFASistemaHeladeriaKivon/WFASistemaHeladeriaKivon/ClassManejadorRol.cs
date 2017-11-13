using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WFASistemaHeladeriaKivon
{
    class ClassManejadorRol
    {
        public List<ClassRol> listaRoles()
        {
            List<ClassRol> listaRol = new List<ClassRol>();
            MySqlConnection conexion = ClassConexion.abrirConexion();
            string sqlListaRoles = "SELECT idRol, nombreRol FROM rol ORDER BY nombreRol;";

            MySqlCommand cmdListaRoles = new MySqlCommand(sqlListaRoles, conexion);
            MySqlDataReader drLecturaDeConsulta = cmdListaRoles.ExecuteReader();

            while (drLecturaDeConsulta.Read())
            {
                ClassRol objRol = new ClassRol();
                objRol.IdRol = drLecturaDeConsulta.GetInt32(0);
                objRol.NombreRol = drLecturaDeConsulta.GetString(1);

                listaRol.Add(objRol);
            }
            return listaRol;
        }
    }
}
