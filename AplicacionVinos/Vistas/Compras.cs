using AplicacionVinos.Config;
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
            try
            {
                // VALIDACIONES BÁSICAS
                if (cb_Proveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un proveedor.");
                    return;
                }

                string cod = txt_cod.Text.Trim();
                if (string.IsNullOrWhiteSpace(cod))
                {
                    MessageBox.Show("Ingrese un código.");
                    txt_cod.Focus();
                    return;
                }

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

                // VALIDAR CODIGO EN BD (si existe en BD, no permitir)
                if (ProductoAT.ExisteCodigo(cod))
                {
                    MessageBox.Show("El código ya existe en la base de datos.");
                    return;
                }

                // VALIDAR CODIGO EN EL DGV (ya agregado en la compra actual)
                foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
                {
                    if (fila.Cells["cod"].Value != null && fila.Cells["cod"].Value.ToString() == cod)
                    {
                        MessageBox.Show("El código ya fue cargado en esta compra.");
                        return;
                    }
                }

                // CÁLCULOS: descuento reduce el precio (no suma)
                decimal pUnit = costo * (1 - descuento / 100m);   // precio unitario con descuento
                decimal ganancia = pUnit - costo;                 // puede ser negativa si descuento > 0
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
