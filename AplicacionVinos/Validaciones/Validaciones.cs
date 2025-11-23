using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionVinos.Validaciones
{
    internal class Validaciones
    {
        public static bool ValidarEmail(string email)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, patron);
        }

        public static bool ValidarUsuario(string usuario)
        {
            string patron = @"^[a-zA-Z0-9]{4,16}$";
            return Regex.IsMatch(usuario, patron);
        }

        public static bool ValidarPassword(string password)
        {
            string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(password, patron);
        }
        public static bool CampoObligatorio(Control ctrl)
        {
            string texto = "";

            if (ctrl is TextBox)
                texto = ((TextBox)ctrl).Text;
            else if (ctrl is ComboBox)
                texto = ((ComboBox)ctrl).Text;

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Este campo es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                return false;
            }

            return true;
        }

        public void DeshabilitarShortcuts(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ShortcutsEnabled = false;
                }
                // Si hay controles contenedores (GroupBox, Panel, etc.), recorrerlos también
                else if (control.HasChildren)
                {
                    DeshabilitarShortcutsEnControles(control);
                }
            }
        }

        private void DeshabilitarShortcutsEnControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ShortcutsEnabled = false;
                }
                else if (control.HasChildren)
                {
                    DeshabilitarShortcutsEnControles(control);
                }
            }
        }
    }
}
