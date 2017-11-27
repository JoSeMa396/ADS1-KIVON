using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASistemaHeladeriaKivon
{
    public partial class IUClientes : Form
    {
        public IUClientes()
        {
            InitializeComponent();
        }

        private void button_registrarCliente_Click(object sender, EventArgs e)
        {
            List<string> camposRepetidos = new List<string>();
            ClassCliente objetoCliente = new ClassCliente();
            ClassManejadorCliente objetoManejadorCliente = new ClassManejadorCliente();
            //validar campos vacios
            if (textBox_ciCliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un CI");
                textBox_ciCliente.Focus();
                return;
            }
            if (textBox_nitCliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un CI");
                textBox_nitCliente.Focus();
                return;
            }
            if (textBox_primerNombreCliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un CI");
                textBox_primerNombreCliente.Focus();
                return;
            }
            if (textBox_apellidoPaternoCliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un CI");
                textBox_apellidoPaternoCliente.Focus();
                return;
            }
            //fin validar campos vacios
            if (objetoManejadorCliente.validarCi(textBox_ciCliente.Text) != null)
            {
                camposRepetidos.Add(objetoManejadorCliente.validarCi(textBox_ciCliente.Text));
            }
            if (camposRepetidos.Count() != 0)
            {
                string msj = "";
                foreach (var item in camposRepetidos)
                {
                    msj += item + "\n";
                }

                MessageBox.Show("estos datos ya estan registrados:\n " + msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int verificarRegistrocliente = 0;//Variable para verificar si se registro el usuario correctamente
            int idSucursal = 1;//Variable que se mantiene constante hasta realizar el autentificar y capturar el codigo de sucursal
            string ci = textBox_ciCliente.Text;
            string lugarExpedicion = Convert.ToString(cmbLugarExpedicion.Text);
            string nit = textBox_nitCliente.Text;
            string primerNombre = textBox_primerNombreCliente.Text;
            string segundoNombre = textBox_segundoNombreCliente.Text;
            string apellidoPaterno = textBox_apellidoPaternoCliente.Text;
            string apellidoMaterno = textBox_apellidoMaternoCLiente.Text;

            objetoCliente.IdSucursal = idSucursal;
            objetoCliente.Ci = ci;
            objetoCliente.LugarExpedicion = lugarExpedicion;
            objetoCliente.Nit = nit;
            objetoCliente.PrimerNombre = primerNombre;
            objetoCliente.SegundoNombre = segundoNombre;
            objetoCliente.ApellidoPaterno = apellidoPaterno;
            objetoCliente.ApellidoMaterno = apellidoMaterno;

            verificarRegistrocliente = objetoManejadorCliente.RegistrarCliente(objetoCliente);
            if (verificarRegistrocliente != 0)
            {
                MessageBox.Show("El usuario se registro exitosamente");
                ResetearCampos();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario");
            }
        }
        public void ResetearCampos()
        {
            cmbLugarExpedicion.Text = "";
            textBox_ciCliente.Text = "";
            textBox_nitCliente.Text = "";
            textBox_primerNombreCliente.Text = "";
            textBox_segundoNombreCliente.Text = "";
            textBox_apellidoPaternoCliente.Text = "";
            textBox_apellidoMaternoCLiente.Text = "";
        }
    }
}
