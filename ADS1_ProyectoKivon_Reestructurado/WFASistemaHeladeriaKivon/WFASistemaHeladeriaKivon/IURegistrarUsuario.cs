﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASistemaHeladeriaKivon
{
    public partial class IURegistrarUsuario : Form
    {
        //==============================================================================================================
        //METODOS PRINCIPALES

        public IURegistrarUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarDataGridListaUsuarios();
            llenarComboBoxRol();
            picBoxFotoUser.ImageLocation = @"C:\Users\TOSHIBA\Desktop\proyecto final_ADS1\ADS1_ProyectoKivon_Reestructurado\media\imagenes\download.png";
        }
        // carga el form

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetearCampos();
        }
        // cancela la entrada de datos, limpiando el formulario

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.NumeroLetra(e);
        }
        //valida las entradas al txt de ci

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }
        //valida las entradas al txt de primer nombre

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text != string.Empty)
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
        }
        //obtiene datos del txt de primer nombre para crear un nombre de usuario y contrasenha

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }
        //valida las entradas al txt de segundo nombre

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }
        //valida las entradas al txt de apellido paterno

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text != string.Empty)
                txtLogin.Text = txtPrimerNombre.Text.Substring(0, 1) + txtApellidoPaterno.Text;
        }
        //obtiene datos del txt de apellido paterno para crear un nombre de usuario y contrasenha

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloLetras(e);
        }
        //valida las entradas al txt de apellido materno

        private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.soloNumeros(e);
        }
        //valida las entradas al txt de numero celular

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassValidarEntradas v = new ClassValidarEntradas();
            v.NumeroLetra(e);
        }
        //valida las entradas al txt de login (nombre de usuario)

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Text = txtLogin.Text;
        }
        //

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picBoxFotoUser.ImageLocation = openFileDialog1.FileName;
        }
        //permite elegir una fotografia para el usuario

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClassManejadorUsuario objManejadorUsuario = new ClassManejadorUsuario();
            ClassUsuario objetoUsuario = new ClassUsuario();

            if (verificiarCamposVacios().Count != 0)
            {
                string vacios = "";

                foreach (var item in verificiarCamposVacios())
                {
                    vacios += "\n - " + item;
                }

                MessageBox.Show("campos vacios, llenelos por favor:" + vacios, "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (objManejadorUsuario.verificarDatosRepetidos(txtCi.Text, txtNumeroCelular.Text, txtLogin.Text).Count != 0)
                {
                    string repetidos = "";

                    foreach (var item in objManejadorUsuario.verificarDatosRepetidos(txtCi.Text, txtNumeroCelular.Text, txtLogin.Text))
                    {
                        repetidos += "\n" + item;
                    }

                    MessageBox.Show("Los siguientes datos ingresados ya fueron utilizados, cambielos por favor:" + repetidos, "datos ya utilizados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    int verificarRegistroUsuario = 0;//Variable para verificar si se registro el usuario correctamente

                    int idRol = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                    int idSucursal = 1;//Variable que se mantiene constante hasta realizar el autentificar y capturar el codigo de sucursal
                    string ci = txtCi.Text;
                    string lugarExpedicion = cmbLugarExpedicion.Text;
                    string fechaNacimiento = dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");
                    string primerNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrimerNombre.Text);
                    string segundoNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSegundoNombre.Text);
                    string apellidoPaterno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoPaterno.Text);
                    string apellidoMaterno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidoMaterno.Text);
                    int numeroCelular = Int32.Parse(txtNumeroCelular.Text);
                    string login = txtLogin.Text;
                    string password = txtPassword.Text;
                    bool activo = true;
                    activo = rdbSi.Checked == true ? true : false;
                    string rutaFoto = picBoxFotoUser.ImageLocation;

                    // poner las variables del windows form al objeto usuario
                    objetoUsuario.IdRol = idRol;
                    objetoUsuario.IdSucursal = idSucursal;
                    objetoUsuario.Ci = ci;
                    objetoUsuario.PrimerNombre = primerNombre;
                    objetoUsuario.SegundoNombre = segundoNombre;
                    objetoUsuario.ApellidoPaterno = apellidoPaterno;
                    objetoUsuario.ApellidoMaterno = apellidoMaterno;
                    objetoUsuario.FechaNacimiento = fechaNacimiento;
                    objetoUsuario.LugarExpedicion = lugarExpedicion;
                    objetoUsuario.NumeroCelular = numeroCelular;
                    objetoUsuario.Login = login;
                    objetoUsuario.Password = password;
                    objetoUsuario.Activo = activo;
                    objetoUsuario.ImagenFotografia = rutaFoto;

                    verificarRegistroUsuario = objManejadorUsuario.RegistrarUsuario(objetoUsuario);

                    if (verificarRegistroUsuario != 0)
                    {
                        MessageBox.Show("El usuario se registro exitosamente");
                        ResetearCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el usuario");
                    }

                    ResetearCampos();

                    actualizarDataGridView();
                }
            }
        }
        //registra el los datos en el formulario como nuevo usuario

        //==============================================================================================================
        //METODOS SECUNDARIOS

        public void llenarDataGridListaUsuarios()
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
                Name = "NombreRol",
                HeaderText = "Cargo",
                DataPropertyName = "NombreRol"
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

        public List<string> verificiarCamposVacios()
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
        // verifica que los campos obligatorios a llenar no esten vacios
    }
}
