using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Heladeria_1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        List<Usuario> ListaUsuarios = new List<Usuario>();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int n = identificarUsuario(txtId.Text, txtPassword.Text);
            if(n != 0)
            {
                FormOpcionesUsuario Opciones = new FormOpcionesUsuario(n);
                this.Hide();
                Opciones.Show();
            }
            else
            {
                MessageBox.Show("id y/o password incorrecto/s");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            ManejadorUsuario lista = new ManejadorUsuario();
            ListaUsuarios = lista.listaUsuarios();
        }

        private int identificarUsuario(string id, string pass)
        {
            int pase = 0;
            foreach (var item in ListaUsuarios)
            {
                if (item.login.Equals(id) == true && item.password.Equals(pass) == true)
                {
                    pase = item.idRol;
                    break;
                }

            }
            return pase;
        }
    }
}
