using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFASistemaHeladeriaKivon
{
    class ClassUsuario : ClassPersona
    {
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
        public string FechaNacimiento { get; set; }
        public int NumeroCelular { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ImagenFotografia { get; set; }
        public bool Activo { get; set; }

        public ClassUsuario() { }

        public ClassUsuario(int IdRol, int IdSucursal, string FechaNacimiento, int NumeroCelular, string Login, string Password, string ImagenFotografia, bool Activo)
        {
            this.IdRol = IdRol;
            this.IdSucursal = IdSucursal;
            this.FechaNacimiento = FechaNacimiento;
            this.NumeroCelular = NumeroCelular;
            this.Login = Login;
            this.Password = Password;
            this.ImagenFotografia = ImagenFotografia;
            this.Activo = Activo;
        }

        public string NombreCompleto
        {
            get { return ApellidoPaterno + " " + ApellidoMaterno + " " + PrimerNombre + " " + SegundoNombre; }
        }

        public string CiCompleto
        {
            get { return Ci + " " + LugarExpedicion; }
        }
    }
}
