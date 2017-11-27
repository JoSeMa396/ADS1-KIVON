using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFASistemaHeladeriaKivon
{
    public class ClassPersona
    {
        private int idPersona;
        private string ci;
        private string lugarExpedicion;
        private string primerNombre;
        private string segundoNombre;
        private string apellidoPaterno;
        private string apellidoMaterno;

        public ClassPersona() { }

        public ClassPersona(string ci, string primerNombre, string segundoNombre, string apellidoPaterno, string apellidoMaterno)
        {
            this.ci = Ci;
            this.primerNombre = PrimerNombre;
            this.segundoNombre = SegundoNombre;
            this.apellidoPaterno = ApellidoPaterno;
            this.apellidoMaterno = ApellidoMaterno;
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }

        public string LugarExpedicion
        {
            get { return lugarExpedicion; }
            set { lugarExpedicion = value; }
        }

        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }

        public string SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

    }
}
