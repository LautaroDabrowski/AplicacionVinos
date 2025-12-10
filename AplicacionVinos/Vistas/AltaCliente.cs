using AplicacionVinos.Config;
using System;
using System.Windows.Forms;

namespace AplicacionVinos.Vistas
{
    public partial class AltaCliente : Form
    {
        ClienteAT clienteAT = new ClienteAT();

        public AltaCliente()
        {
            InitializeComponent();
            CargarEstados();
        }


        private void CargarEstados()
        {
            cb_Estado.Items.Clear();
            cb_Estado.Items.Add("Activo");
            cb_Estado.Items.Add("Inactivo");
            cb_Estado.SelectedIndex = 0;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de controles
                if (string.IsNullOrWhiteSpace(txt_Apellido.Text) ||
                    string.IsNullOrWhiteSpace(txt_Nombres.Text))
                {
                    MessageBox.Show("Nombre y Apellido son obligatorios.",
                        "Campos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Cliente cli = new Cliente
                {
                    CuitCuil = txt_Cuil_Cuit.Text,
                    Apellido = txt_Apellido.Text,
                    Nombre = txt_Nombres.Text,
                    Email = txt_Correo.Text,
                    Telefono = txt_Telefono.Text,
                    Direccion = txt_Direccion.Text,
                    RazonSocial = txt_RS.Text,
                    Estado = cb_Estado.SelectedItem.ToString() == "Activo"
                };

                // Llamada al backend
                bool insertado = clienteAT.AgregarCli(cli);

                if (insertado)
                {
                    MessageBox.Show("Cliente agregado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txt_Cuil_Cuit.Text = "";
            txt_Apellido.Text = "";
            txt_Nombres.Text = "";
            txt_Correo.Text = "";
            txt_Telefono.Text = "";
            txt_Direccion.Text = "";
            txt_RS.Text = "";
            cb_Estado.SelectedIndex = 0;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            EditarCliente frm = new EditarCliente();
            frm.ShowDialog();   // Se abre como ventana modal
        }
    }
}
