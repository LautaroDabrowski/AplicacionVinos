using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionVinos.Vistas
{
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void Administracion_Load(object sender, EventArgs e)
        {

        }

        private Form FormAbierto = null;

        private void FormMuestra(Form formMuestra)
        {
            if (FormAbierto != null)
                FormAbierto.Close();

            FormAbierto = formMuestra; // Guarda el formulario en una variable.
            formMuestra.TopLevel = false; // El formulario no es de nivel superior y se comporta igual que un control.
            formMuestra.FormBorderStyle = FormBorderStyle.None; // Saca los bordes del formulario.
            formMuestra.Dock = DockStyle.Fill; // Rellena el panel con el formulario.
            PanelFormsAd.Controls.Add(formMuestra); // Agrega el formulario a la lista de control del panel.
            PanelFormsAd.Tag = formMuestra; // Asocia el formulario con el panel contenedor.
            formMuestra.BringToFront(); // Trae hacia adelante el formulario.
            formMuestra.Show(); // Muestra el formulario.
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormMuestra(new ConfigurarPerfilAdmin());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMuestra(new AltaCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMuestra(new HistorialVentasCompras());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMuestra(new AltaUsuario());
        }
    }
}
