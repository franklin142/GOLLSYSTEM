using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Validation
{
    public class Keypress
    {
        public static void KeyPress_UsuarioName(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        public static void KeyPress_Pass(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        public static void KeyPress_IP(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        public static void KeyPress_Num_Letras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void KeyPress_Desercion(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && !char.IsWhiteSpace(e.KeyChar) && !(e.KeyChar == Convert.ToChar(";")) && !(e.KeyChar == Convert.ToChar(".")) && !(e.KeyChar == Convert.ToChar(",")))
            {
                e.Handled = true;
            }
        }
        public static void Validar_IP(TextBox txtIP, ErrorProvider error)
        {
            if (txtIP.Text.Trim() != "localhost")
            {
                Regex myRegex = new Regex("^(([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.){3}([01]?\\d\\d?|25[0-5]|2[0-4]\\d)$");
                if (myRegex.IsMatch(txtIP.Text.Trim()))
                {

                }
                else
                {
                    error.SetError(txtIP, "IP erronea");
                }
            }

        }
        public static void Validar_Puerto(TextBox txtPuerto, ErrorProvider error)
        {
            if (txtPuerto.Text.Length != 4)
                error.SetError(txtPuerto, "Puerto debe tener 4 digitos");
            else
                error.Clear();
        }
        public static void KeyPress_Numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
