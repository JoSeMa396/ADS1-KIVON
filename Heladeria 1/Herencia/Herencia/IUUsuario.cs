using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herencia
{
    public partial class IUUsuario : Form
    {
        public IUUsuario()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void IUUsuario_Load(object sender, EventArgs e)
        {
            llenarDataGridListaUsuarios();//metodo que llena datos del databgrid
            llenarComboBoxRol();//metodo para llenar el combo box
        }

        //metodo para llenar el comboBOX de rol
        public void llenarComboBoxRol()
        {
            ManejadorRol objRol = new ManejadorRol();
            cmbTipoUsuario.DataSource = objRol.listaRoles();
            cmbTipoUsuario.DisplayMember = "nombreRol";
            cmbTipoUsuario.ValueMember = "idRol";
        }


        //metodo para llenar datos de usuarios en el datagrid
        public void llenarDataGridListaUsuarios()
        {
            ManejadorUsuario objManejadorUsuario = new ManejadorUsuario();
            dtgListaUsuarios.DataSource = null;
            dtgListaUsuarios.AutoGenerateColumns = false;

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "idPersona",
                HeaderText = "ID de Usuario",
                DataPropertyName = "idPersona"
            });

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreCompleto",
                HeaderText = "Nombre Completo",
                DataPropertyName = "NombreCompleto"
            });

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CiCompleto",
                HeaderText = "Carnet de identidad",
                DataPropertyName = "CiCompleto"
            });

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "fechaNacimiento",
                HeaderText = "fecha de nacimiento",
                DataPropertyName = "fechaNacimiento"
            });

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "numeroCelular",
                HeaderText = "Celular",
                DataPropertyName = "numeroCelular"
            });

            dtgListaUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ArgActivo",
                HeaderText = "Estado",
                DataPropertyName = "ArgActivo"
            });

            dtgListaUsuarios.DataSource = objManejadorUsuario.listaUsuarios();
        }
        //analizar
        public void actualizarDataGridView()
        {
            ManejadorUsuario objManejadorUsuario = new ManejadorUsuario();
            dtgListaUsuarios.DataSource = null;
            dtgListaUsuarios.AutoGenerateColumns = false;
            dtgListaUsuarios.DataSource = objManejadorUsuario.listaUsuarios();
            dtgListaUsuarios.Refresh();
        }

        public void LimpiarCampos()
        {
            picBoxFotoUser.InitialImage = null;
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtCi.Text = "";
            cmbTipoUsuario.Text = "";
            cmbLugarExpedicion.Text = "";
            txtNumeroCelular.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            List<string> camposRepetidos = new List<string>();
            Usuario objetoUsuario = new Usuario();
            ManejadorUsuario objetoManejadorUsuario = new ManejadorUsuario();
            // validacion de los campos
            //if()


            if (txtCi.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un CI");
                txtCi.Focus();
                return;
            }
            /*int ciVerif = 0;
            if(!int.TryParse(txtCi.Text, out ciVerif))
            {
                MessageBox.Show("Debe ingresar un CI numerico");
                txtCi.Focus();
                return;
            }
            if(ciVerif <= 0 )
            {
                MessageBox.Show("Debe ingresar un CI numerico mayor a cero");
                txtCi.Focus();
                return;
            }*/

            if(cmbLugarExpedicion.Text == string.Empty)
            {
                MessageBox.Show("Debe elegir un Lugar de Expedicion de su carnet ");
                cmbLugarExpedicion.Focus();
                return;
            }

            if (txtPrimerNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Nombre " );
                txtPrimerNombre.Focus();
                return;
            }
            
            if (txtApellidoPaterno.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Apellido ");
                txtApellidoPaterno.Focus();
                return;
            }

            if (txtNumeroCelular.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un Numero de Celular ");
                txtNumeroCelular.Focus();
                return;
            }
            int celVerif = 0;
            if (!int.TryParse(txtNumeroCelular.Text, out celVerif))
            {
                MessageBox.Show("Debe ingresar un Numero entero");
                txtNumeroCelular.Focus();
                return;
            }
            if (celVerif <= 0)
            {
                MessageBox.Show("Debe ingresar un Numero mayor a cero");
                txtNumeroCelular.Focus();
                return;
            }//end validar campos
            //
            if (objetoManejadorUsuario.validarFoto(picBoxFotoUser.ImageLocation) != null)
            {
                camposRepetidos.Add(objetoManejadorUsuario.validarFoto(picBoxFotoUser.ImageLocation));
            }
            if (objetoManejadorUsuario.validarCi(txtCi.Text) != null)
            {
                camposRepetidos.Add(objetoManejadorUsuario.validarCi(txtCi.Text));
            }
            if (objetoManejadorUsuario.validarCelular(txtNumeroCelular.Text) != null)
            {
                camposRepetidos.Add(objetoManejadorUsuario.validarCelular(txtNumeroCelular.Text));
            }
            if (objetoManejadorUsuario.validarUsuario(txtLogin.Text) != null)
            {
                camposRepetidos.Add(objetoManejadorUsuario.validarUsuario(txtLogin.Text));
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

            int verificarRegistroUsuario = 0;//Variable para verificar si se registro el usuario correctamente

            int idRol = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
            int idSucursal = 1;//Variable que se mantiene constante hasta realizar el autentificar y capturar el codigo de sucursal
            string ci = txtCi.Text;
            //string lugarExpedicion = "Cochabamba";
            string lugarExpedicion = cmbLugarExpedicion.Text;
            //MessageBox.Show("Exp" + lugarExpedicion);
            string fechaNacimiento = dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");
            string primerNombre = txtPrimerNombre.Text;
            string segundoNombre = txtSegundoNombre.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string apellidoMaterno = txtApellidoMaterno.Text;

            int numeroCelular = Int32.Parse(txtNumeroCelular.Text);

            

            string login = txtLogin.Text;
            string password = txtPassword.Text;
            bool activo = true; //el usuario al ser registrado es activo por defecto

            activo = rdbSi.Checked == true ? true : false;
            string rutaFoto = picBoxFotoUser.ImageLocation;


            // poner las variables del windows form al objeto usuario
            objetoUsuario.idRol = idRol;
            objetoUsuario.idSucursal = idSucursal;
            objetoUsuario.Ci = ci;
            objetoUsuario.PrimerNombre = primerNombre;
            objetoUsuario.SegundoNombre = segundoNombre;
            objetoUsuario.ApellidoPaterno = apellidoPaterno;
            objetoUsuario.ApellidoMaterno = apellidoMaterno;
            objetoUsuario.fechaNacimiento = fechaNacimiento;
            objetoUsuario.lugarExpedicion = lugarExpedicion;
            objetoUsuario.numeroCelular = numeroCelular;
            objetoUsuario.login = login;
            objetoUsuario.password = password;
            objetoUsuario.activo = activo;
            objetoUsuario.imagenFotografia = rutaFoto;

            verificarRegistroUsuario = objetoManejadorUsuario.RegistrarUsuario(objetoUsuario);
            if (verificarRegistroUsuario != 0){
                MessageBox.Show("El usuario se registro exitosamente");
                VaciarCampos();
            }
            else {
                MessageBox.Show("Error al registrar el usuario");
            }

            actualizarDataGridView();
            LimpiarCampos();

       }//end registrarUsuario


        private void gpbListaUsuarios_Enter(object sender, EventArgs e)
        {

        }


        private void gpbRegistrarUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void dtgListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void VaciarCampos()
        {
            cmbTipoUsuario.Text = "";
            txtLogin.Text = "";
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picBoxFotoUser.ImageLocation = openFileDialog1.FileName;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Text = txtLogin.Text;
        }

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            txtPrimerNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrimerNombre.Text);
            txtPrimerNombre.SelectionStart = txtPrimerNombre.Text.Length;
            if (txtPrimerNombre.Text != "")
            {
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
            }
            
            //txtPassword.Text = txtLogin.Text;
        }

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            txtApellidoPaterno.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoPaterno.Text);
            txtApellidoPaterno.SelectionStart = txtApellidoPaterno.Text.Length;
            if (txtApellidoPaterno.Text != "")
            {
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
            }
            
            //txtPassword.Text = txtLogin.Text;
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void soloLetras( KeyPressEventArgs e )
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtSegundoNombre_TextChanged(object sender, EventArgs e)
        {
            txtSegundoNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSegundoNombre.Text);
            txtSegundoNombre.SelectionStart = txtSegundoNombre.Text.Length;
        }

        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {
            txtApellidoMaterno.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoMaterno.Text);
            txtApellidoMaterno.SelectionStart = txtApellidoMaterno.Text.Length;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }//end class
}//end namespace
