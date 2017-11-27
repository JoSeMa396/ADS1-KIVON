using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heladeria_1
{
    class Cliente:Persona
    {
        public int IdCliente { get; set; }
        public int IdSucursal { get; set; }
        public string NIT { get; set; }
        public string nombreCompleto { get; set; }
    }
}
