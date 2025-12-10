using AplicacionVinos.Config;
using AplicacionVinos.Validaciones;
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
            // Cargar proveedores apenas se abre
            CargarProveedores();
            ConfigurarGrilla();
            AplicarRestricciones();
        }

        private void AplicarRestricciones()
        {
            // Código (letras + números, máx 6)
            txt_cod.MaxLength = 6;
            txt_cod.KeyPress += (s, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            // Cantidad (solo números, máx 15)
            txt_Cant.MaxLength = 15;
            txt_Cant.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            // Costo (números + coma)
            txt_costo.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) &&
                    e.KeyChar != ',' &&
                    !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // solo una coma permitida
                if (e.KeyChar == ',' && ((TextBox)s).Text.Contains(","))
                    e.Handled = true;
            };

            // Descuento (solo números)
            txt_PDescuento.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };

            // Bloquear edición del total
            txt_TCompra.ReadOnly = true;
        }

        private void ConfigurarGrilla()
        {
            dgv_ProdAgregados.AllowUserToAddRows = false;
            dgv_ProdAgregados.Columns.Clear();

            dgv_ProdAgregados.Columns.Add("cod", "Código");
            dgv_ProdAgregados.Columns.Add("desc", "Descripción");
            dgv_ProdAgregados.Columns.Add("cat", "Categoría");
            dgv_ProdAgregados.Columns.Add("subcat", "Subcategoría");
            dgv_ProdAgregados.Columns.Add("prov", "Proveedor");
            dgv_ProdAgregados.Columns.Add("cant", "Cantidad");
            dgv_ProdAgregados.Columns.Add("costo", "Costo");
            dgv_ProdAgregados.Columns.Add("gan", "% Descuento");
            dgv_ProdAgregados.Columns.Add("pventa", "Precio Venta");
            dgv_ProdAgregados.Columns.Add("total", "Total");
        }

        // PEGÁ AQUÍ ESTE MÉTODO
        private void LimpiarCampos()
        {
            txt_cod.Clear();
            txt_descrip.Clear();
            txt_cat.Clear();
            txt_Subcat.Clear();
            txt_Cant.Clear();
            txt_costo.Clear();
            txt_PDescuento.Clear();

            cb_Proveedor.SelectedIndex = -1;

            txt_cod.Focus();
        }

        // CARGAR LISTA DE PROVEEDORES
        private void CargarProveedores()
        {
            try
            {
                DataTable tabla = (DataTable)ProveedorAT.ObtenerLista();

                cb_Proveedor.DataSource = tabla;
                cb_Proveedor.DisplayMember = "razon_social";
                cb_Proveedor.ValueMember = "id_proveedor";

                cb_Proveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
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


        private void btn_AgregarProd_Click(object sender, EventArgs e)
        {
            // VALIDAR CAMPOS OBLIGATORIOS
            if (!Validar.CampoObligatorio(txt_cod)) return;
            if (!Validar.CampoObligatorio(txt_descrip)) return;
            if (!Validar.CampoObligatorio(txt_cat)) return;
            if (!Validar.CampoObligatorio(txt_Subcat)) return;
            if (!Validar.CampoObligatorio(txt_Cant)) return;
            if (!Validar.CampoObligatorio(txt_costo)) return;
            if (!Validar.CampoObligatorio(txt_PDescuento)) return;
            if (!Validar.CampoObligatorio(cb_Proveedor)) return;

            try
            {
                if (cb_Proveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un proveedor.");
                    return;
                }

                string cod = txt_cod.Text.Trim();
                string desc = txt_descrip.Text.Trim();
                string cat = txt_cat.Text.Trim();
                string subcat = txt_Subcat.Text.Trim();

                if (!int.TryParse(txt_Cant.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    txt_Cant.Focus();
                    return;
                }

                if (!decimal.TryParse(txt_costo.Text.Trim(), out decimal costo))
                {
                    MessageBox.Show("Ingrese un costo válido.");
                    txt_costo.Focus();
                    return;
                }

                if (!decimal.TryParse(txt_PDescuento.Text.Trim(), out decimal descuento))
                    descuento = 0m;

                if (descuento < 0 || descuento > 100)
                {
                    MessageBox.Show("El descuento debe estar entre 0 y 100.");
                    txt_PDescuento.Focus();
                    return;
                }

                int prov = Convert.ToInt32(cb_Proveedor.SelectedValue);

                if (ProductoAT.ExisteCodigo(cod))
                {
                    MessageBox.Show("El código ya existe en la base de datos.");
                    return;
                }

                foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
                {
                    if (fila.Cells["cod"].Value != null &&
                        fila.Cells["cod"].Value.ToString() == cod)
                    {
                        MessageBox.Show("El código ya fue cargado en esta compra.");
                        return;
                    }
                }

                decimal pUnit = costo * (1 - descuento / 100m);
                decimal ganancia = pUnit - costo;
                decimal totalProducto = pUnit * cant;

                dgv_ProdAgregados.Rows.Add(
                    cod, desc, cat, subcat, prov, cant, costo, ganancia, pUnit, totalProducto
                );

                ActualizarTotalCompra();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto:\n" + ex.Message);
            }
        }

        private void ActualizarTotalCompra()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
            {
                if (!fila.IsNewRow)
                {
                    total += Convert.ToDecimal(fila.Cells[9].Value);
                }
            }

            txt_TCompra.Text = total.ToString("0.00");
        }

        private void btn_GenerarCompra_Click(object sender, EventArgs e)
        {
            if (!Validar.CampoObligatorio(cb_Proveedor)) return;

            if (string.IsNullOrWhiteSpace(txt_TCompra.Text))
            {
                MessageBox.Show("No hay total calculado.");
                return;
            }

            try
            {
                if (cb_Proveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un proveedor.");
                    return;
                }

                if (dgv_ProdAgregados.Rows.Count == 0)
                {
                    MessageBox.Show("Debe agregar productos.");
                    return;
                }

                int idProveedor = Convert.ToInt32(cb_Proveedor.SelectedValue);
                int idUsuario = 1; // Usuario logueado

                int idRemito = CompraAT.GenerarCompra(dgv_ProdAgregados, idProveedor, idUsuario);

                MessageBox.Show("Compra generada correctamente. Remito N° " + idRemito);

                dgv_ProdAgregados.Rows.Clear();
                txt_TCompra.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
