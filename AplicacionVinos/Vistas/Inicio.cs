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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private Form FormAbierto = null;

        private void FormMuestra(Form formHijo)
        {
            if (FormAbierto != null)
                FormAbierto.Close(); // Si hay un formulario abierto lo cierra.

            FormAbierto = formHijo; // Guarda el formulario en una variable.
            formHijo.TopLevel = false; // El formulario no es de nivel superior y se comporta igual que un control.
            formHijo.FormBorderStyle = FormBorderStyle.None; // Saca los bordes del formulario.
            formHijo.Dock = DockStyle.Fill; // Rellena el panel con el formulario.
            PanelForms.Controls.Add(formHijo); // Agrega el formulario a la lista de control del panel.
            PanelForms.Tag = formHijo; // Asocia el formulario con el panel contenedor.
            formHijo.BringToFront(); // Trae hacia adelante el formulario.
            formHijo.Show(); // Muestra el formulario.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormMuestra(new Administracion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMuestra(new Productos());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMuestra(new Compras());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormMuestra(new Presupuesto());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMuestra(new Ventas());
        }
    }
}
