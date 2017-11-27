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
    public partial class IULogin : Form
    {
        //==============================================================================================================
        //VARIABLES

        private static IULogin instancia = null;
        List<ClassUsuario> ListaUsuarios = new List<ClassUsuario>();

        //FIN VARIABLES
        //==============================================================================================================
        //METODOS PRIMARIOS

        public IULogin()
        {
            InitializeComponent();
        }

        private void IULogin_Load(object sender, EventArgs e)
        {
            ClassManejadorUsuario lista = new ClassManejadorUsuario();
            ListaUsuarios = lista.listarUsuarios();
        }


        private void IULogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            instancia = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClassManejadorUsuario buscador = new ClassManejadorUsuario();
            ClassUsuario usuarioEncontrado = buscador.VerificarExistenciaUsuario(txtUsuario.Text);

            if (usuarioEncontrado.IdPersona == 0)
            {
                MessageBox.Show("Usuario no encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (usuarioEncontrado.Password != txtPassword.Text)
                {
                    MessageBox.Show("Contraseña incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (usuarioEncontrado.Activo != true)
                    {
                        MessageBox.Show("Su cuenta no esta activa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Close();
                        IUOpcionesUsuario SiguienteInterfaz = new IUOpcionesUsuario(usuarioEncontrado);
                        SiguienteInterfaz.Show();
                    }
                }
            }
        }

        //FIN METODOS PRIMARIOS
        //==============================================================================================================
        //METODOS SECUNDARIOS

        public static IULogin Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new IULogin();
                }
                return instancia;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ClassManejadorUsuario buscador = new ClassManejadorUsuario();
                ClassUsuario usuarioEncontrado = buscador.VerificarExistenciaUsuario(txtUsuario.Text);

                if (usuarioEncontrado.IdPersona == 0)
                {
                    MessageBox.Show("Usuario no encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (usuarioEncontrado.Password != txtPassword.Text)
                    {
                        MessageBox.Show("Contraseña incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (usuarioEncontrado.Activo != true)
                        {
                            MessageBox.Show("Su cuenta no esta activa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Close();
                            IUOpcionesUsuario SiguienteInterfaz = new IUOpcionesUsuario(usuarioEncontrado);
                            SiguienteInterfaz.Show();
                        }
                    }
                }
            }
        }

        //FIN METODOS SECUNDARIOS
        //==============================================================================================================
    }
}
