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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAltaProveedor_Click(object sender, EventArgs e)
        {
            AltaProveedor uc = new AltaProveedor();
            uc.Dock = DockStyle.Fill;

            Form ventana = new Form();
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.ClientSize = uc.Size;


            ventana.Controls.Add(uc);

            ventana.ShowDialog();
        }

        private void Compras_Load(object sender, EventArgs e)
        {

        }

    }
}
