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
    public partial class formCliente : Form
    {
        public formCliente()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cliente ObjCliente = new Cliente();
            ManejadorCliente objManejadorCliente = new ManejadorCliente();
            int exitoInsertarCliennte = 0;//si hay error en la consulta entonces es cero

            ObjCliente.PrimerNombre = txtPnombre.Text;
            ObjCliente.IdSucursal = 1;
            ObjCliente.SegundoNombre = txtSnombre.Text;
            ObjCliente.ApellidoPaterno = txtApaterno.Text;
            ObjCliente.ApellidoMaterno = txtAmaterno.Text;
            ObjCliente.Ci = txtCi.Text;
            ObjCliente.NIT = txtNIT.Text;

            exitoInsertarCliennte = objManejadorCliente.RegistrarCliente(ObjCliente);
            if (exitoInsertarCliennte != 0)
            {
                llenarDataGridListaClientes();
                MessageBox.Show("Se ha registrado correctamente");
                
            }
            else
            {
                MessageBox.Show("no se pudo registrar");
            }
        }

        public void llenarDataGridListaClientes()
        {
            ManejadorCliente objManejadorCliente = new ManejadorCliente();
            dtgListaCliente.DataSource = null;
            dtgListaCliente.AutoGenerateColumns = false;

            dtgListaCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "idCliente",
                HeaderText = "ID de Cliente",
                DataPropertyName = "idCliente"
            });

            dtgListaCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreCompleto",
                HeaderText = "Nombre Completo",
                DataPropertyName = "NombreCompleto"
            });

            dtgListaCliente.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Ci",
                HeaderText = "Carnet de identidad",
                DataPropertyName = "Ci"
            });



            dtgListaCliente.DataSource = objManejadorCliente.ListarClientes();
        }

        public void ActualizarDtg()
        {
            ManejadorCliente objManejadorCliente = new ManejadorCliente();
            dtgListaCliente.DataSource = null;
            dtgListaCliente.AutoGenerateColumns = false;
            dtgListaCliente.DataSource = objManejadorCliente.ListarClientes();
            dtgListaCliente.Refresh();
        }

        private void formCliente_Load(object sender, EventArgs e)
        {
            llenarDataGridListaClientes();

        }

        private void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
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

        private void txtPnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtApaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtNIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtSnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtAmaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtPnombre_TextChanged(object sender, EventArgs e)
        {
            txtPnombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPnombre.Text);
            txtPnombre.SelectionStart = txtPnombre.Text.Length;
        }

        private void txtApaterno_TextChanged(object sender, EventArgs e)
        {
            txtApaterno.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApaterno.Text);
            txtApaterno.SelectionStart = txtApaterno.Text.Length;
        }

        private void txtSnombre_TextChanged(object sender, EventArgs e)
        {
            txtSnombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSnombre.Text);
            txtSnombre.SelectionStart = txtSnombre.Text.Length;
        }

        private void txtAmaterno_TextChanged(object sender, EventArgs e)
        {
            txtAmaterno.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtAmaterno.Text);
            txtAmaterno.SelectionStart = txtAmaterno.Text.Length;
        }

        private void dtgListaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
