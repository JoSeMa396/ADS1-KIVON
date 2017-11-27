using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Cliente: Persona
    {
        public int idSucursal { get; set; }
        public string nit { get; set; }

        public Cliente() { }

        public Cliente(int idSucursal, string nit) {
            this.idSucursal = idSucursal;
            this.nit = nit;
        }


    }//end class
}//end namespace
