using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria_1
{
    class Usuario:Persona
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int idSucursal { get; set; }
        public string fechaNacimiento { get; set; }
        public string lugarExpedicion { get; set; }
        public int numeroCelular { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string imagenFotografia { get; set; }
        public bool activo { get; set; }
        public string nombreCompleto;
        public string ciCompleto;
        public string argActivo;

        public Usuario() { }

        public Usuario(int idRol, int idSucursal, string fechaNacimiento, string lugarExpedicion, int numeroCelular, string login, string password, string imagenFotografia, bool activo)
        {
            this.idRol = idRol;
            this.idSucursal = idSucursal;
            this.fechaNacimiento = fechaNacimiento;
            this.lugarExpedicion = lugarExpedicion;
            this.numeroCelular = numeroCelular;
            this.login = login;
            this.password = password;
            this.imagenFotografia = imagenFotografia;
            this.activo = activo;
        }
        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string CiCompleto
        {
            get { return ciCompleto; }
            set { ciCompleto = value; }
        }

        public string ArgActivo
        {
            get { return argActivo; }
            set
            {
                argActivo = value;
            }
        }
    }
}
