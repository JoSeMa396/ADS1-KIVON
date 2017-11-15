using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Heladeria_1
{
    class ManejadorCliente
    {
        public int RegistrarCliente(Cliente objCliente)
        {
            int exitoInsertarCliente = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlRegistrarCliente = "insert into cliente(primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, ci, nit) values(?primerNombre, ?segundoNombre, ?apellidoPaterno, ?apellidoMaterno, ?ci, ?NIT);";
            MySqlCommand cmdRegistrarCliente = new MySqlCommand(sqlRegistrarCliente, conexion);

            cmdRegistrarCliente.Parameters.Add("?primerNombre", objCliente.PrimerNombre);
            cmdRegistrarCliente.Parameters.Add("?segundoNombre", objCliente.SegundoNombre);
            cmdRegistrarCliente.Parameters.Add("apellidoPaterno", objCliente.ApellidoPaterno);
            cmdRegistrarCliente.Parameters.Add("?apellidoMaterno", objCliente.ApellidoMaterno);
            cmdRegistrarCliente.Parameters.Add("?Ci", objCliente.Ci);
            cmdRegistrarCliente.Parameters.Add("?NIT", objCliente.NIT);

            try
            {
                exitoInsertarCliente = cmdRegistrarCliente.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            conexion.Close();
            return exitoInsertarCliente;
        }
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            MySqlConnection conexion = Conexion.abrirConexion();
            string sqlListarCliente = "select idCliente, ci, nit, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno from cliente order by idCliente asc;";
            MySqlCommand cmdListarCliente = new MySqlCommand(sqlListarCliente, conexion);

            MySqlDataReader drLecturaConsulta = cmdListarCliente.ExecuteReader();
            while (drLecturaConsulta.Read())
            {
                Cliente objCliente = new Cliente();
                objCliente.IdCliente = drLecturaConsulta.GetInt32(0);
                objCliente.nombreCompleto = drLecturaConsulta.GetString(3) + " " + drLecturaConsulta.GetString(4) + " " + drLecturaConsulta.GetString(5) + " " + drLecturaConsulta.GetString(6);
                objCliente.Ci = drLecturaConsulta.GetString(2);
                objCliente.NIT = drLecturaConsulta.GetString(3);
                listaCliente.Add(objCliente);
            }
            return listaCliente;
        }




    }
}
