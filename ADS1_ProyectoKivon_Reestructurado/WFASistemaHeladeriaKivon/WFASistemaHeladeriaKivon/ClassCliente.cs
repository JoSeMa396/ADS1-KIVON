using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFASistemaHeladeriaKivon
{
    class ClassCliente : ClassPersona
    {
        public int IdSucursal { get; set; }
        public string Nit { get; set; }
        //public string NombreCompleto { get; internal set; }

        public ClassCliente() { }

        public ClassCliente(int idSucursal, string nit)
        {
            this.IdSucursal = idSucursal;
            this.Nit = nit;
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
