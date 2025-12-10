<<<<<<< Updated upstream
<<<<<<< Updated upstream
﻿using AplicacionVinos.Config;
=======
﻿using AplicacionVinos.BD;
using AplicacionVinos.Config;
>>>>>>> Stashed changes
=======
﻿using AplicacionVinos.BD;
using AplicacionVinos.Config;
>>>>>>> Stashed changes
using AplicacionVinos.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
                // VALIDACIONES
                if (!Validar.CampoObligatorio(txt_cod)) return;
                if (!Validar.CampoObligatorio(txt_descrip)) return;
                if (!Validar.CampoObligatorio(cb_Cat)) return;
                if (!Validar.CampoObligatorio(cb_SubCat)) return;
                if (!Validar.CampoObligatorio(txt_Cant)) return;
                if (!Validar.CampoObligatorio(txt_costo)) return;

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                if (cb_Proveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un proveedor.");
                    return;
                }

                string cod = txt_cod.Text.Trim();
                string desc = txt_descrip.Text.Trim();
                string categoria = cb_Cat.Text.Trim();
                string subcategoria = cb_SubCat.Text.Trim();

                // VALIDAR NÚMEROS
                if (!int.TryParse(txt_Cant.Text.Trim(), out int cant) || cant <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.");
                    return;
                }

                if (!decimal.TryParse(txt_costo.Text.Trim(), out decimal costo) || costo <= 0)
                {
                    MessageBox.Show("El costo debe ser válido.");
                    return;
                }

                if (!decimal.TryParse(txt_PDescuento.Text.Trim(), out decimal descuento))
                    descuento = 0;

                if (descuento < 0 || descuento > 100)
                {
                    MessageBox.Show("El porcentaje debe estar entre 0 y 100.");
                    return;
                }

                int idProveedor = Convert.ToInt32(cb_Proveedor.SelectedValue);

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
                // ❌ NO PERMITIR CÓDIGO YA EN BD
>>>>>>> Stashed changes
=======
                // ❌ NO PERMITIR CÓDIGO YA EN BD
>>>>>>> Stashed changes
                if (ProductoAT.ExisteCodigo(cod))
                {
                    MessageBox.Show("El código ya existe en la base de datos.");
                    return;
                }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
                foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
                {
                    if (fila.Cells["cod"].Value != null &&
                        fila.Cells["cod"].Value.ToString() == cod)
=======
                // ❌ NO PERMITIR CÓDIGO YA CARGADO EN GRILLA
                foreach (DataGridViewRow row in dgv_ProdAgregados.Rows)
                {
                    if (row.Cells["cod"].Value?.ToString() == cod)
>>>>>>> Stashed changes
=======
                // ❌ NO PERMITIR CÓDIGO YA CARGADO EN GRILLA
                foreach (DataGridViewRow row in dgv_ProdAgregados.Rows)
                {
                    if (row.Cells["cod"].Value?.ToString() == cod)
>>>>>>> Stashed changes
                    {
                        MessageBox.Show("Este producto ya fue agregado en esta compra.");
                        return;
                    }
                }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
                decimal pUnit = costo * (1 - descuento / 100m);
                decimal ganancia = pUnit - costo;
                decimal totalProducto = pUnit * cant;
=======
                // ✔ OBTENER O CREAR CATEGORÍA
                int idCat = CategoriaAT.ObtenerOCrear(categoria);
>>>>>>> Stashed changes
=======
                // ✔ OBTENER O CREAR CATEGORÍA
                int idCat = CategoriaAT.ObtenerOCrear(categoria);
>>>>>>> Stashed changes

                // ✔ OBTENER O CREAR SUBCATEGORÍA
                int idSubCat = SubCategoriaAT.ObtenerOCrear(subcategoria, idCat);

                // CALCULOS
                decimal precioVenta = costo * (1 - descuento / 100m);
                decimal total = precioVenta * cant;

                // AGREGAR A LA TABLA
                dgv_ProdAgregados.Rows.Add(
                    cod,
                    desc,
                    categoria,
                    subcategoria,
                    idProveedor,
                    cant,
                    costo,
                    descuento,
                    precioVenta,
                    total
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

                // CREAR REMITO / COMPRA
                string qCompra = @"
            INSERT INTO compras (fecha, id_proveedor, total)
            OUTPUT INSERTED.id_compra
            VALUES (GETDATE(), @prov, @total)";

                decimal totalCompra = 0;
                foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
                    totalCompra += Convert.ToDecimal(fila.Cells["total"].Value);

                int idCompra = Convert.ToInt32(Conexion.EjecutarUnico(
                    qCompra,
                    new SqlParameter("@prov", idProveedor),
                    new SqlParameter("@total", totalCompra)
                ));


                // PROCESAR CADA PRODUCTO

                foreach (DataGridViewRow fila in dgv_ProdAgregados.Rows)
                {
                    string cod = fila.Cells["cod"].Value.ToString();
                    string desc = fila.Cells["desc"].Value.ToString();
                    string cat = fila.Cells["cat"].Value.ToString();
                    string subcat = fila.Cells["subcat"].Value.ToString();

                    int cant = Convert.ToInt32(fila.Cells["cant"].Value);
                    decimal costo = Convert.ToDecimal(fila.Cells["costo"].Value);
                    decimal precioVenta = Convert.ToDecimal(fila.Cells["pventa"].Value);
                    decimal ganancia = precioVenta - costo;


                    // OBTENER O CREAR CATEGORÍA

                    int idCategoria = CategoriaAT.ObtenerOCrear(cat);

                    // OBTENER O CREAR SUBCATEGORÍA

                    int idSubcategoria = SubCategoriaAT.ObtenerOCrear(subcat, idCategoria);


                    // OBTENER O CREAR PRODUCTO

                    int idProducto;

                    if (ProductoAT.ExisteCodigo(cod))
                    {
                        idProducto = ProductoAT.ObtenerIdPorCodigo(cod);
                    }
                    else
                    {
                        idProducto = ProductoAT.InsertarProducto(
                            cod, desc, costo, precioVenta, ganancia,
                            idCategoria, idSubcategoria, idProveedor
                        );

                        // crear stock en 0
                        ProductoAT.CrearStock(idProducto, 0);
                    }


                    // INSERTAR DETALLE DE COMPRA

                    string qDet = @"
                INSERT INTO compras_detalle (id_compra, id_producto, cantidad, precio)
                VALUES (@compra, @prod, @cant, @costo)";

                    Conexion.EjecutarABM(
                        qDet,
                        new SqlParameter("@compra", idCompra),
                        new SqlParameter("@prod", idProducto),
                        new SqlParameter("@cant", cant),
                        new SqlParameter("@costo", costo)
                    );

                    
                    // ACTUALIZAR STOCK
                    
                    string qStock =
                        "UPDATE stock SET cantidad = cantidad + @cant WHERE id_producto = @prod";

                    Conexion.EjecutarABM(
                        qStock,
                        new SqlParameter("@cant", cant),
                        new SqlParameter("@prod", idProducto)
                    );

                  
                    // INSERTAR MOVIMIENTO
              
                    string qMov = @"
                INSERT INTO movimientos (id_producto, tipo, cantidad, fecha)
                VALUES (@prod, 'COMPRA', @cant, GETDATE())";

                    Conexion.EjecutarABM(
                        qMov,
                        new SqlParameter("@prod", idProducto),
                        new SqlParameter("@cant", cant)
                    );
                }

                MessageBox.Show("Compra generada correctamente. Remito N° " + idCompra);

                dgv_ProdAgregados.Rows.Clear();
                txt_TCompra.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            cb_Cat.DataSource = CategoriaAT.ObtenerTodas();
            cb_Cat.DisplayMember = "categoria";
            cb_Cat.ValueMember = "id_categoria";

            cb_Cat.SelectedIndexChanged += cb_Cat_SelectedIndexChanged;
        }

        private void cb_Cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_Cat.SelectedValue == null) return;

                int idCat = Convert.ToInt32(cb_Cat.SelectedValue);

                DataTable tablaSub = SubCategoriaAT.ObtenerPorCategoria(idCat);

                cb_SubCat.DataSource = tablaSub;
                cb_SubCat.DisplayMember = "subcategoria";
                cb_SubCat.ValueMember = "id_subcategoria";

                cb_SubCat.SelectedIndex = -1;
            }
            catch (Exception)
            {
                // Para evitar errores cuando el combo se llena por primera vez
            }
        }
    }
}
