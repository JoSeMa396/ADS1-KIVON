using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFASistemaHeladeriaKivon
{
    class ClassEmpresa
    {
        public string Nombre { get; set; }
        public int NumeroSucursal { get; set; }
        public int NIT { get; set; }
        public int NumAutorizacion { get; set; }
        public string Direccion { get; set; }
        public List<ClassTelefonoCelular> TelefonosCelulares { get; set; }

        public ClassEmpresa()
        {

        }

        public ClassEmpresa(string Nombre, int NumeroSucursal, int NIT, int NumAutorizacion, string Direccion, List<ClassTelefonoCelular> TelefonosCelulares)
        {

        }
    }
}
