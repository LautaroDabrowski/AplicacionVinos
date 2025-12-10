using AplicacionVinos.BD;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AplicacionVinos.Config
{
    internal class CompraAT
    {
        public static int GenerarCompra(DataGridView dgv, int idProveedor, int idUsuario)
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow fila in dgv.Rows)
                subtotal += Convert.ToDecimal(fila.Cells["total"].Value);

            decimal descuento = 0m;
            decimal totalFinal = subtotal - descuento;


            // INSERTAR CABECERA h_compras

            string qRemito = @"
                INSERT INTO h_compras (cod_usuario, id_proveedor, subtotal, descu, total)
                OUTPUT INSERTED.id_remito
                VALUES (@u, @p, @sub, @des, @tot)";

            SqlParameter[] pr =
            {
                new SqlParameter("@u", idUsuario),
                new SqlParameter("@p", idProveedor),
                new SqlParameter("@sub", subtotal),
                new SqlParameter("@des", descuento),
                new SqlParameter("@tot", totalFinal)
            };

            int idRemito = Convert.ToInt32(Conexion.EjecutarUnico(qRemito, pr));


            // GUARDAR DETALLE + STOCK + MOVIMIENTOS

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                string cod = fila.Cells["cod"].Value.ToString();
                string desc = fila.Cells["desc"].Value.ToString();
                int cant = Convert.ToInt32(fila.Cells["cant"].Value);
                decimal punit = Convert.ToDecimal(fila.Cells["pventa"].Value);
                decimal total = Convert.ToDecimal(fila.Cells["total"].Value);

                // Obtener ID producto
                int idProd = ProductoAT.ObtenerIdPorCodigo(cod);
                if (idProd == 0)
                    throw new Exception("No existe producto con código " + cod);

                // Insertar detalle
                string qDet = @"
                    INSERT INTO h_compras_detalle
                    (id_remito, cod_prod, descr, p_unit, cant, p_x_cant)
                    VALUES (@idR, @idP, @d, @u, @c, @t)";

                SqlParameter[] pd =
                {
                    new SqlParameter("@idR", idRemito),
                    new SqlParameter("@idP", idProd),
                    new SqlParameter("@d", desc),
                    new SqlParameter("@u", punit),
                    new SqlParameter("@c", cant),
                    new SqlParameter("@t", total)
                };

                Conexion.EjecutarABM(qDet, pd);

                // Actualizar stock
                string qStock = "UPDATE stock SET cantidad = cantidad + @c WHERE id_producto = @idP";
                SqlParameter[] ps =
                {
                    new SqlParameter("@c", cant),
                    new SqlParameter("@idP", idProd)
                };
                Conexion.EjecutarABM(qStock, ps);

                // Movimiento
                string qMov = @"
                    INSERT INTO h_movimientos
                    (id_producto, id_usuario, tipo_movimiento, cantidad, origen_tabla, id_origen, detalle)
                    VALUES (@idP, @u, 'COMPRA', @c, 'h_compras', @idR, @d)";

                SqlParameter[] pm =
                {
                    new SqlParameter("@idP", idProd),
                    new SqlParameter("@u", idUsuario),
                    new SqlParameter("@c", cant),
                    new SqlParameter("@idR", idRemito),
                    new SqlParameter("@d", "Compra de producto")
                };

                Conexion.EjecutarABM(qMov, pm);
            }

            return idRemito;
        }
    }
}
