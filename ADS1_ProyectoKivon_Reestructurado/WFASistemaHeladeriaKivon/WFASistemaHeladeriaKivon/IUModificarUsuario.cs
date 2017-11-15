using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WFASistemaHeladeriaKivon
{
    public partial class IUModificarUsuario : Form
    {
        private ClassManejadorUsuario objManejadorUsuario = new ClassManejadorUsuario();
        private ClassUsuario objetoUsuario;

        public IUModificarUsuario()
        {
            InitializeComponent();
        }

        private void IUModificarUsuario_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            llenarDataGridListaUsuarios();
            llenarComboBoxRol();
            picBoxFotoUser.ImageLocation = @"C:\Users\TOSHIBA\Desktop\proyecto final_ADS1\ADS1_ProyectoKivon_Reestructurado\media\imagenes\download.png";
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.NumeroLetra(e);
        }//valida las entradas al txt de ci

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }//valida las entradas al txt de primer nombre

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text != string.Empty)
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
        }//obtiene datos del txt de primer nombre para crear un nombre de usuario y contrasenha

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }//valida las entradas al txt de segundo nombre

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }//valida las entradas al txt de apellido paterno

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text != string.Empty)
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
        }//obtiene datos del txt de apellido paterno para crear un nombre de usuario y contrasenha

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }//valida las entradas al txt de apellido materno

        private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloNumeros(e);
        }//valida las entradas al txt de numero celular

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.NumeroLetra(e);
        }//valida las entradas al txt de login (nombre de usuario)

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Text = txtLogin.Text;
        }//

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picBoxFotoUser.ImageLocation = openFileDialog1.FileName;
        }//permite elegir una fotografia para el usuario

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetearCampos();
        }// cancela la entrada de datos, limpiando el formulario

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objetoUsuario = new ClassUsuario();
            int idUsuario = Convert.ToInt32(dtgListaUsuarios.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("Desea modificar al usuario con un id Usuario : " + dtgListaUsuarios.SelectedRows[0].Cells[0].Value, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                objetoUsuario = objManejadorUsuario.pedirUsuario(idUsuario);

                cmbTipoUsuario.SelectedIndex = objetoUsuario.IdRol - 1;
                picBoxFotoUser.ImageLocation = objetoUsuario.ImagenFotografia;
                txtCi.Text = objetoUsuario.Ci;
                cmbLugarExpedicion.Text = objetoUsuario.LugarExpedicion;
                txtPrimerNombre.Text = objetoUsuario.PrimerNombre;
                txtSegundoNombre.Text = objetoUsuario.SegundoNombre;
                txtApellidoPaterno.Text = objetoUsuario.ApellidoPaterno;
                txtApellidoMaterno.Text = objetoUsuario.ApellidoMaterno;
                dtpFechaNacimiento.Text = objetoUsuario.FechaNacimiento;
                txtNumeroCelular.Text = objetoUsuario.NumeroCelular.ToString();
                txtLogin.Text = objetoUsuario.Login;
                txtPassword.Text = objetoUsuario.Password;

                btnGuardar.Enabled = true;
            }
        }//selecciona un usuario del dataGrigView y copia todos sus datos en el formulario

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarCamposVacios().Count != 0)
            {
                string vacios = "";

                foreach (var item in verificarCamposVacios())
                {
                    vacios += "\n - " + item;
                }

                MessageBox.Show("campos vacios, llenelos por favor:" + vacios, "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                if (objManejadorUsuario.verificarDatosRepetidos(txtCi.Text, txtNumeroCelular.Text, txtLogin.Text, objetoUsuario.IdPersona).Count != 0)
                {
                    string repetidos = "";

                    foreach (var item in objManejadorUsuario.verificarDatosRepetidos(txtCi.Text, txtNumeroCelular.Text, txtLogin.Text, objetoUsuario.IdPersona))
                    {
                        repetidos += "\n   - " + item;
                    }

                    MessageBox.Show("Los siguientes datos ingresados ya fueron utilizados, cambielos por favor:" + repetidos, "datos ya utilizados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    int idRol = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                    string ci = txtCi.Text;
                    string lugarExpedicion = Convert.ToString(cmbLugarExpedicion.Text);
                    string fechaNacimiento = dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");
                    string primerNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrimerNombre.Text);
                    string segundoNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSegundoNombre.Text);
                    string apellidoPaterno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoPaterno.Text);
                    string apellidoMaterno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoMaterno.Text);
                    int numeroCelular = int.Parse(txtNumeroCelular.Text);
                    string foto = picBoxFotoUser.ImageLocation;
                    string login = txtLogin.Text;
                    string password = txtPassword.Text;

                    int verificarModificacion = 0;

                    objetoUsuario.IdRol = idRol;
                    objetoUsuario.Ci = ci;
                    objetoUsuario.LugarExpedicion = lugarExpedicion;
                    objetoUsuario.FechaNacimiento = fechaNacimiento;
                    objetoUsuario.PrimerNombre = primerNombre;
                    objetoUsuario.SegundoNombre = segundoNombre;
                    objetoUsuario.ApellidoPaterno = apellidoPaterno;
                    objetoUsuario.ApellidoMaterno = apellidoMaterno;
                    objetoUsuario.NumeroCelular = numeroCelular;
                    objetoUsuario.ImagenFotografia = foto;
                    objetoUsuario.Login = login;
                    objetoUsuario.Password = password;

                    verificarModificacion = objManejadorUsuario.modificarUsuario(objetoUsuario, objetoUsuario.IdPersona);

                    if (verificarModificacion != 0)
                    {
                        MessageBox.Show("El usuario se actualizo exitosamente");
                        ResetearCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el usuario");
                    }
                    ResetearCampos();

                    btnGuardar.Enabled = false;

                    actualizarDataGridView();
                }
            }
        }//guarda los datos del usuario seleccionado anteriormente, si es que se realizaron cambios en el formulario
        //==============================================================================================================
        //METODOS SECUNDARIOS

        private void llenarDataGridListaUsuarios()
        {
            ClassManejadorUsuario objManejadorUsuario = new ClassManejadorUsuario();
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
                DataPropertyName = "Activo"
            });

            dtgListaUsuarios.DataSource = objManejadorUsuario.listarUsuarios();
        }
        // llena de datos el DataGridView

        public void actualizarDataGridView()
        {
            ClassManejadorUsuario objManejadorUsuario = new ClassManejadorUsuario();
            dtgListaUsuarios.DataSource = null;
            dtgListaUsuarios.AutoGenerateColumns = false;
            dtgListaUsuarios.DataSource = objManejadorUsuario.listarUsuarios();
            dtgListaUsuarios.Refresh();
        }
        // actualiza los datos almacenados en el DataGridView

        public void llenarComboBoxRol()
        {
            ClassManejadorRol objRol = new ClassManejadorRol();
            cmbTipoUsuario.DataSource = objRol.listaRoles();
            cmbTipoUsuario.DisplayMember = "nombreRol";
            cmbTipoUsuario.ValueMember = "idRol";
        }
        // llena de datos el comboBox de roles

        public void ResetearCampos()
        {
            cmbTipoUsuario.Text = "";
            txtCi.Text = "";
            txtLogin.Text = "";
            picBoxFotoUser.ImageLocation = @"C:\Users\TOSHIBA\Desktop\proyecto final_ADS1\ADS1_ProyectoKivon_Reestructurado\media\imagenes\download.png";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            cmbLugarExpedicion.Text = "";
            txtNumeroCelular.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";

        }
        // vacia todo los campos del formulario

        public List<string> verificarCamposVacios()
        {
            List<string> vacios = new List<string>();

            if (cmbTipoUsuario.Text == string.Empty)
            {
                vacios.Add("Tipo de usuario");
            }

            if (txtCi.Text == string.Empty)
            {
                vacios.Add("CI");
            }

            if (cmbLugarExpedicion.Text == string.Empty)
            {
                vacios.Add("Lugar de expedición");
            }

            if (txtPrimerNombre.Text == string.Empty)
            {
                vacios.Add("Primer nombre");
            }

            if (txtApellidoPaterno.Text == string.Empty)
            {
                vacios.Add("Apellido paterno");
            }

            if (txtNumeroCelular.Text == string.Empty)
            {
                vacios.Add("Número celular");
            }
            return vacios;
        }
    }
}
