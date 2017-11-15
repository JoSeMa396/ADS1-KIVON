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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("cliente") == true && textBox2.Text.Equals("123") == true)
            {
                formCliente clienteForm = new formCliente();
                this.Hide();
                clienteForm.Show();
            }
            else
            {
                MessageBox.Show("cliente y/o password incorrecto");
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("usuario") == true && textBox2.Text.Equals("123") == true)
            {
                formUsuario clienteForm = new formUsuario();
                this.Hide();
                clienteForm.Show();
            }
            else
            {
                MessageBox.Show("usuario y/o password incorrecto");
            }
        }
    }
}
