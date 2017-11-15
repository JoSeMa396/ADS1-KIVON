using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heladeria_1
{
    public partial class FormOpcionesUsuario : Form
    {
        public int op = 0;
        public FormOpcionesUsuario(int n)
        {
            this.op = n;
            InitializeComponent();
        }
        private void FormOpcionesUsuario_Load(object sender, EventArgs e)
        {
            IdentificarUsuario(op);
        }
        private void IdentificarUsuario(int a)
        {
            switch (a)
            {
                case 1:
                    lblCabecera.Text = "Administrador";
                    break;
                case 3:
                    lblCabecera.Text = "Cajero";
                    btnProveedores.Visible = false;
                    btnProductos.Visible = false;
                    btnCatalogo.Visible = false;
                    btnUsuario.Visible = false;
                    break;
                case 4:
                    lblCabecera.Text = "Contador";
                    btnProveedores.Visible = false;
                    btnProductos.Visible = false;
                    btnCatalogo.Visible = false;
                    btnUsuario.Visible = false;
                    btnFacturas.Visible = false;
                    btnClientes.Visible = false;
                    btnCompras.Location = new Point(300, 15);
                    break;
                default:
                    break;
            }
            pnlOpciones.Visible = true;
        }
    }
}
