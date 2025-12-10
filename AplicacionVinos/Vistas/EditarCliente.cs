using AplicacionVinos.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AplicacionVinos.Vistas
{
    public partial class EditarCliente : Form
    {
        ClienteAT clienteAT = new ClienteAT();
        int idSeleccionado = 0;
        public EditarCliente()
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
        private void button2_Click(object sender, EventArgs e)
        {
            string dni = txt_Dni.Text;
            string nombre = txt_NomApe.Text; // se usa para nombre o apellido
            string apellido = ""; // ya no se usa

            DataTable tabla = clienteAT.BuscarClientes(dni, nombre, apellido);
            dgv_BuscarCli.DataSource = tabla;
        }

        // -------- DOBLE CLIC EN UN CLIENTE --------
        private void dgv_BuscarCli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idSeleccionado = Convert.ToInt32(dgv_BuscarCli.Rows[e.RowIndex].Cells["id_cliente"].Value);

            Cliente cli = clienteAT.ObtenerCliente(idSeleccionado);

            if (cli == null) return;

            txt_DNICli.Text = cli.CuitCuil;
            txt_Nom.Text = cli.Nombre;
            txt_Ape.Text = cli.Apellido;
            txt_RSocial.Text = cli.RazonSocial;
            txt_Telef.Text = cli.Telefono;
            txt_CoElec.Text = cli.Email;
            txt_Direcc.Text = cli.Direccion;
            cb_Estado.SelectedIndex = cli.Estado ? 0 : 1;
        }

        private void btn_GuardarCam_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            Cliente cli = new Cliente
            {
                id_cliente = idSeleccionado,
                CuitCuil = txt_DNICli.Text,
                Nombre = txt_Nom.Text,
                Apellido = txt_Ape.Text,
                RazonSocial = txt_RSocial.Text,
                Telefono = txt_Telef.Text,
                Email = txt_CoElec.Text,
                Direccion = txt_Direcc.Text,
                Estado = cb_Estado.SelectedItem.ToString() == "Activo"
            };

            bool ok = clienteAT.EditarCliente(cli);

            if (ok)
            {
                MessageBox.Show("Cliente actualizado correctamente.");
                button2.PerformClick(); // Recargar búsqueda
            }
        }
    }
}
