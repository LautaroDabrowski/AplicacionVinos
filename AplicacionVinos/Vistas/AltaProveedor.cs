using AplicacionVinos.BD;
using AplicacionVinos.Config;
using AplicacionVinos.Validaciones;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AplicacionVinos.Vistas
{
    public partial class AltaProveedor : UserControl
    {
        public AltaProveedor()
        {
            InitializeComponent();
            ConfigurarGrilla();   //IMPORTANTE
        }

        // CREAR COLUMNAS DE LA GRILLA (OBLIGATORIO)
        private void ConfigurarGrilla()
        {
            dgv_AgrProv.Columns.Clear();
            dgv_AgrProv.AutoGenerateColumns = false;

            dgv_AgrProv.Columns.Add("colRazon", "Razón Social");
            dgv_AgrProv.Columns.Add("colCuit", "CUIT");
            dgv_AgrProv.Columns.Add("colTel", "Teléfono");
            dgv_AgrProv.Columns.Add("colDirecc", "Dirección");
            dgv_AgrProv.Columns.Add("colEmail", "Email");
        }


        // BOTÓN AGREGAR PROVEEDOR A LA GRILLA
        private void btn_AgregarProv_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar.CampoObligatorio(txt_RSocial)) return;
                if (!Validar.CampoObligatorio(txt_Cuit)) return;
                if (!Validar.CampoObligatorio(txt_Tel)) return;
                if (!Validar.CampoObligatorio(txt_Direcc)) return;
                if (!Validar.CampoObligatorio(txt_Email)) return;

                if (!Validar.ValidarEmail(txt_Email.Text))
                {
                    MessageBox.Show("El email ingresado no es válido.");
                    return;
                }

                // Evitar duplicado en grilla
                foreach (DataGridViewRow fila in dgv_AgrProv.Rows)
                {
                    if (!fila.IsNewRow &&
                        fila.Cells["colCuit"].Value?.ToString() == txt_Cuit.Text)
                    {
                        MessageBox.Show("El proveedor ya fue cargado en la lista.");
                        return;
                    }
                }

                // Agregar fila a la grilla
                dgv_AgrProv.Rows.Add(
                    txt_RSocial.Text,
                    txt_Cuit.Text,
                    txt_Tel.Text,
                    txt_Direcc.Text,
                    txt_Email.Text
                );

                // Limpieza
                txt_RSocial.Clear();
                txt_Cuit.Clear();
                txt_Tel.Clear();
                txt_Direcc.Clear();
                txt_Email.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar proveedor:\n" + ex.Message);
            }
        }

        // GUARDAR PROVEEDORES EN LA BASE DE DATOS
        private void btn_GuardarProv_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_AgrProv.Rows.Count == 0)
                {
                    MessageBox.Show("No hay proveedores cargados para guardar.");
                    return;
                }

                foreach (DataGridViewRow fila in dgv_AgrProv.Rows)
                {
                    if (fila.IsNewRow) continue;

                    ProveedorAT prov = new ProveedorAT
                    {
                        Razon = fila.Cells["colRazon"].Value?.ToString(),
                        Cuit = fila.Cells["colCuit"].Value?.ToString(),
                        Telefono = fila.Cells["colTel"].Value?.ToString(),
                        Direccion = fila.Cells["colDirecc"].Value?.ToString(),
                        Email = fila.Cells["colEmail"].Value?.ToString()
                    };

                    if (string.IsNullOrWhiteSpace(prov.Cuit))
                    {
                        MessageBox.Show("Error: CUIT vacío.");
                        return;
                    }

                    if (prov.ExisteEnBD())
                    {
                        MessageBox.Show($"El proveedor con CUIT {prov.Cuit} ya está registrado.");
                        continue;
                    }

                    if (!prov.Guardar())
                    {
                        MessageBox.Show("Error al guardar un proveedor.");
                        return;
                    }
                }

                MessageBox.Show("Proveedores guardados correctamente.");
                dgv_AgrProv.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedores:\n" + ex.Message);
            }
        }
    }
}