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
    public partial class IUOpcionesUsuario : Form
    {
        //==============================================================================================================
        //VARIABLES

        private ClassUsuario UsuarioActual;
        private IURegistrarUsuario IURegistrarUsuario = new IURegistrarUsuario();
        private IUModificarUsuario IUModificarUsuario = new IUModificarUsuario();
        private IUClientes IUClientes = new IUClientes();
        //FIN VARIABLES
        //==============================================================================================================
        //METODOS PRIMARIOS
        public IUOpcionesUsuario(ClassUsuario UsuarioActual)
        {
            this.UsuarioActual = UsuarioActual;
            InitializeComponent();
        }

        private void IUOpcionesUsuario_Load(object sender, EventArgs e)
        {
            lblCabecera.Text = UsuarioActual.NombreRol + ": " + UsuarioActual.NombreCompleto;
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿desea cerrar su sesion?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IURegistrarUsuario.IsDisposed == true)
            {
                IURegistrarUsuario = new IURegistrarUsuario();
                IURegistrarUsuario.Show();
            }
            else
                IURegistrarUsuario.Show();
        }

        private void administrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IUModificarUsuario.IsDisposed == true)
            {
                IUModificarUsuario = new IUModificarUsuario();
                IUModificarUsuario.Show();
            }
            else
                IUModificarUsuario.Show();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IUClientes.IsDisposed == true)
            {
                IUClientes = new IUClientes();
                IUClientes.Show();
            }
            else
                IUClientes.Show();
        }

        //FIN METODOS PRIMARIOS
        //==============================================================================================================
        //METODOS SECUNDARIOS

        private void IdentificarUsuario(int a)
        {

        }

        //FIN METODOS SECUNDARIOS
        //==============================================================================================================
    }
}
