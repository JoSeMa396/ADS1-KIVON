using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFASistemaHeladeriaKivon
{
    public class ClassValidarEntradas
    {
        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }

            catch (Exception ex)
            {

            }
        }
        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }

            catch (Exception ex)
            {

            }
        }
        public void NumeroLetra(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                    e.Handled = false;
                else if (char.IsLetter(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }

            catch (Exception ex)
            {

            }
        }
    }
}
