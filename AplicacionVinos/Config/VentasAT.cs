using AplicacionVinos.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionVinos.Config
{
    internal class VentasAT
    {
        // Método para crear un remito de venta
        public bool GenerarRemitoVenta(int idUsuario, int idCliente, List<ProductoVenta> productos, decimal descuento)
        {
            using (var connection = new SqlConnection(Conexion.cadena))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Calcular subtotal
                        decimal subtotal = 0;
                        foreach (var producto in productos)
                        {
                            subtotal += producto.PrecioUnitario * producto.Cantidad;
                        }

                        decimal montoDescuento = subtotal * (descuento / 100m);
                        decimal total = subtotal - montoDescuento;

                        // Insertar remito (usar SCOPE_IDENTITY para obtener id)
                        string insertVenta = @"
                            INSERT INTO h_ventas (cod_usuario, fecha_hora, id_cliente, subtotal, descu, total)
                            VALUES (@cod_usuario, @fecha_hora, @id_cliente, @subtotal, @descu, @total);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);
                        ";

                        using (var cmdVenta = new SqlCommand(insertVenta, connection, transaction))
                        {
                            cmdVenta.Parameters.AddWithValue("@cod_usuario", idUsuario);
                            cmdVenta.Parameters.AddWithValue("@fecha_hora", DateTime.Now);
                            cmdVenta.Parameters.AddWithValue("@id_cliente", idCliente);
                            cmdVenta.Parameters.AddWithValue("@subtotal", subtotal);
                            cmdVenta.Parameters.AddWithValue("@descu", montoDescuento);
                            cmdVenta.Parameters.AddWithValue("@total", total);

                            object idObj = cmdVenta.ExecuteScalar();
                            if (idObj == null)
                                throw new Exception("No se pudo obtener el id del remito generado.");

                            int idRemito = Convert.ToInt32(idObj);

                            // Insertar detalle por cada producto
                            string insertDetalle = @"
                                INSERT INTO h_ventas_detalle (id_remito, cod_prod, descr, p_unit, cant, p_x_cant)
                                VALUES (@id_remito, @cod_prod, @descr, @p_unit, @cant, @p_x_cant);
                            ";

                            foreach (var producto in productos)
                            {
                                using (var cmdDetalle = new SqlCommand(insertDetalle, connection, transaction))
                                {
                                    cmdDetalle.Parameters.AddWithValue("@id_remito", idRemito);
                                    cmdDetalle.Parameters.AddWithValue("@cod_prod", producto.CodigoProducto);
                                    cmdDetalle.Parameters.AddWithValue("@descr", producto.Descripcion ?? "");
                                    cmdDetalle.Parameters.AddWithValue("@p_unit", producto.PrecioUnitario);
                                    cmdDetalle.Parameters.AddWithValue("@cant", producto.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@p_x_cant", producto.PrecioUnitario * producto.Cantidad);

                                    cmdDetalle.ExecuteNonQuery();
                                }
                            }

                            // Commit
                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        MessageBox.Show($"Error al generar remito de venta: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }

    // Clase auxiliar para representar un producto en la venta (igual que tenías)
    public class ProductoVenta
    {
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public ProductoVenta(string codigoProducto, string descripcion, decimal precioUnitario, int cantidad)
        {
            CodigoProducto = codigoProducto;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }
}   }

