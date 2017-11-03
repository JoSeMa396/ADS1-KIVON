using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class ReferenciaUsuario: Persona
    {
        public int idReferenciaUsuario { get; private set; }
        public int idUsuario { get; set; }
        public string numeroCelular { get; set; }
        public string lugarExpedicion { get; set; }
        public string imagenFotografiaCarnet { get; set; }

        public ReferenciaUsuario() { }

        public ReferenciaUsuario(int idUsuario,string numeroCelular,string lugarExpedicion,string imagenFotografiaCarnet) {
            this.idUsuario = idUsuario;
            this.numeroCelular = numeroCelular;
            this.lugarExpedicion = lugarExpedicion;
            this.imagenFotografiaCarnet = imagenFotografiaCarnet;
        }



    }
}
