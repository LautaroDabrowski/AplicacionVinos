using AplicacionVinos.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AplicacionVinos.Config
{
    internal class ProductoAT
    {
        public static bool ExisteCodigo(string codigo)
        {
            string q = "SELECT COUNT(*) FROM productos WHERE cod_producto = @c";

            SqlParameter p = new SqlParameter("@c", codigo);

            int cant = Convert.ToInt32(Conexion.EjecutarUnico(q, new SqlParameter[] { p }));
            return cant > 0;
        }

        public static int InsertarProducto(string cod, string desc, decimal costo, decimal precio,
                                           decimal ganancia, int cat, int subcat, int prov)
        {
            string q = @"INSERT INTO productos
                        (cod_producto, prod_desc, precio, costo, ganancia, cod_categoria, cod_subcat, id_proveedor)
                        OUTPUT INSERTED.id_producto
                        VALUES (@cod, @desc, @precio, @costo, @ganancia, @cat, @subcat, @prov)";

            SqlParameter[] p =
            {
                new SqlParameter("@cod", cod),
                new SqlParameter("@desc", desc),
                new SqlParameter("@precio", precio),
                new SqlParameter("@costo", costo),
                new SqlParameter("@ganancia", ganancia),
                new SqlParameter("@cat", cat),
                new SqlParameter("@subcat", subcat),
                new SqlParameter("@prov", prov)
            };

            return Convert.ToInt32(Conexion.EjecutarUnico(q, p));
        }

        public static void CrearStock(int idProd, int cantidad)
        {
            string q = @"INSERT INTO stock (id_producto, cantidad)
                         VALUES (@id, @cant)";

            SqlParameter[] p =
            {
                new SqlParameter("@id", idProd),
                new SqlParameter("@cant", cantidad)
            };

            Conexion.EjecutarABM(q, p);
        }

        public static int ObtenerIdPorCodigo(string cod)
        {
            string q = "SELECT id_producto FROM productos WHERE cod_producto = @c";
            SqlParameter p = new SqlParameter("@c", cod);

            object r = Conexion.EjecutarUnico(q, new SqlParameter[] { p });
            return r == null ? 0 : Convert.ToInt32(r);
        }
    }
}
