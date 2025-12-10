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
    public partial class Ventas : Form
    {
        private ClienteAT clienteAT = new ClienteAT();
        private VentasAT ventasAT = new VentasAT();
        private DataTable dtDetalle;
        public Ventas()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            // FECHA: permite HOY y días pasados, pero NO futuros
            dt_Fecha.MaxDate = DateTime.Today;
            dt_Fecha.Value = DateTime.Today;

            // Crear DataTable correctamente
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("CodigoProducto");
            dtDetalle.Columns.Add("Descripcion");
            dtDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("Descuento", typeof(decimal));
            dtDetalle.Columns.Add("Importe", typeof(decimal));

            // Configurar el DataGridView
            dgv_Gremito.AutoGenerateColumns = true;
            dgv_Gremito.DataSource = dtDetalle;

            dgv_Gremito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";
            dgv_Gremito.Columns["Importe"].DefaultCellStyle.Format = "N2";

            CargarClientesEnCombo();
        }

        private void CargarClientesEnCombo()
        {
            // BuscarClientes con todos los parámetros vacíos debería devolver todos los clientes
            DataTable dt = clienteAT.BuscarClientes("", "", "");
            cb_NCliente.DisplayMember = "nombre"; // ajustar si quieres mostrar "razonsocial"
            cb_NCliente.ValueMember = "id_cliente";
            cb_NCliente.DataSource = dt;
            cb_NCliente.SelectedIndex = -1;
        }

        // BOTON BUSCAR: busca cliente seleccionado en cb_NCliente o busca por CUIT si lo ingresan en txt_CuitN
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (cb_NCliente.SelectedValue != null && int.TryParse(cb_NCliente.SelectedValue.ToString(), out int idCliente))
            {
                LlenarDatosClientePorId(idCliente);
            }
            else if (!string.IsNullOrWhiteSpace(txt_CuitN.Text))
            {
                DataTable res = clienteAT.BuscarClientes(txt_CuitN.Text, "", "");
                if (res.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(res.Rows[0]["id_cliente"]);
                    LlenarDatosClientePorId(id);
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente o ingresa CUIT para buscar.");
            }
        }

        private void LlenarDatosClientePorId(int idCliente)
        {
            var cli = clienteAT.ObtenerCliente(idCliente);
            if (cli == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }

            txt_Cliente.Text = $"{cli.Nombre} {cli.Apellido}";
            txt_NClient.Text = cli.id_cliente.ToString();
            txt_Local.Text = ""; // si tienes campo localidad, mapear
            txt_Direcc.Text = cli.Direccion;
            txt_CuitN.Text = cli.CuitCuil;

            // IVA: llenar checkboxes según reglas de tu negocio. Aquí dejo ejemplo genérico:
            // checkBox1 = Responsable Inscripto
            // checkBox2 = Exento
            // checkBox3 = Consumidor final
            // checkBox4 = No responsable
            // Asumiré que la tabla clientes trae info de tipo de IVA; si no, dejar en false
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = true; // por ejemplo
            checkBox4.Checked = false;
        }

        // BOTON AGREGAR PRODUCTO: valida y agrega fila al dgv
        private void btn_AgregarProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_codProd.Text))
            {
                MessageBox.Show("Ingrese código de producto.");
                return;
            }

            if (!decimal.TryParse(txt_PUnit.Text, out decimal pUnit))
            {
                MessageBox.Show("Precio unitario inválido.");
                return;
            }

            if (!int.TryParse(txt_Cant.Text, out int cantidad))
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            decimal descuento = 0;
            decimal.TryParse(txt_Pdescuento.Text, out descuento);

            // ✔ Calcular el importe
            decimal subtotal = pUnit * cantidad;
            decimal importe = subtotal - (subtotal * (descuento / 100));

            // ✔ Crear fila y agregar al DataTable
            DataRow row = dtDetalle.NewRow();
            row["CodigoProducto"] = txt_codProd.Text;
            row["PrecioUnitario"] = pUnit;
            row["Cantidad"] = cantidad;
            row["Descuento"] = descuento;
            row["Importe"] = importe;

            dtDetalle.Rows.Add(row);

            // ✔ Actualizar total
            ActualizarTotal();

            // limpiar campos:
            // txt_codProd.Clear();
            // txt_PUnit.Clear();
            // txt_Cant.Clear();
            // txt_Pdescuento.Clear();
        }

        private void ActualizarTotal()
        {
            decimal total = 0m;

            foreach (DataRow r in dtDetalle.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                if (decimal.TryParse(r["Importe"].ToString(), out decimal imp))
                    total += imp;
            }

            txt_Total.Text = total.ToString("0.00");
        }

        // BOTON IMPRIMIR REMITO: arma lista de productos, verifica cliente (lo crea si fue cargado manualmente), llama a VentasAT.GenerarRemitoVenta
        private void btn_ImprRemito_Click(object sender, EventArgs e)
        {
            // Recolectar productos desde dgv
            List<ProductoVenta> productos = new List<ProductoVenta>();
            foreach (DataGridViewRow row in dgv_Gremito.Rows)
            {
                if (row.IsNewRow) continue;

                string codigoProducto = row.Cells["CodigoProducto"].Value?.ToString() ?? "";
                string descripcion = row.Cells["Descripcion"].Value?.ToString() ?? "";
                if (!decimal.TryParse(row.Cells["PrecioUnitario"].Value?.ToString(), out decimal precioUnitario))
                    precioUnitario = 0;
                if (!int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out int cantidad))
                    cantidad = 0;

                productos.Add(new ProductoVenta(codigoProducto, descripcion, precioUnitario, cantidad));
            }

            if (productos.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto al remito.");
                return;
            }

            // Obtener o crear cliente
            int idCliente = 0;
            if (int.TryParse(txt_NClient.Text, out int idFromTxt) && idFromTxt > 0)
            {
                idCliente = idFromTxt;
            }
            else if (!string.IsNullOrWhiteSpace(txt_CuitN.Text))
            {
                // Intentar buscar por CUIT
                DataTable res = clienteAT.BuscarClientes(txt_CuitN.Text, "", "");
                if (res.Rows.Count > 0)
                {
                    idCliente = Convert.ToInt32(res.Rows[0]["id_cliente"]);
                }
                else
                {
                    // Crear cliente nuevo a partir de los campos
                    var nuevo = new Cliente
                    {
                        CuitCuil = txt_CuitN.Text,
                        Nombre = txt_Cliente.Text, // si nombre y apellido por separado, mapear
                        Apellido = "",
                        RazonSocial = txt_Cliente.Text,
                        Telefono = "",
                        Email = "",
                        Direccion = txt_Direcc.Text,
                        Estado = true
                    };

                    bool agregado = clienteAT.AgregarCliente(nuevo);
                    if (!agregado)
                    {
                        MessageBox.Show("No se pudo agregar el cliente. Verifica los datos.");
                        return;
                    }

                    // Recuperar id del cliente recién insertado
                    DataTable nuevoRes = clienteAT.BuscarClientes(txt_CuitN.Text, "", "");
                    if (nuevoRes.Rows.Count == 0)
                    {
                        MessageBox.Show("No se pudo recuperar el ID del cliente agregado.");
                        return;
                    }
                    idCliente = Convert.ToInt32(nuevoRes.Rows[0]["id_cliente"]);
                }
            }
            else
            {
                MessageBox.Show("Debe completar datos del cliente o seleccionar uno existente.");
                return;
            }

            // Obtener descuento general del remito (si aplica)
            decimal descuentoGral = 0;
            if (!string.IsNullOrWhiteSpace(txt_Pdescuento.Text))
                decimal.TryParse(txt_Pdescuento.Text, out descuentoGral);

            // Llamar a la capa de negocio para generar remito
            bool exito = ventasAT.GenerarRemitoVenta(3, idCliente, productos, descuentoGral); // idUsuario = 1 por defecto, ajustar

            if (exito)
            {
                MessageBox.Show("Remito generado correctamente.");
                // Opcional: imprimir o abrir reporte
                // Limpiar dgv
                dgv_Gremito.Rows.Clear();
                ActualizarTotal();
            }
            else
            {
                MessageBox.Show("Hubo un error al generar el remito.");
            }
        }
    }
}
