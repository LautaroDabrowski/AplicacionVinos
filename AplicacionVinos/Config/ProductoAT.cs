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
        // Verifica si el código ya existe
        public static bool ExisteCodigo(string codigo)
        {
            string q = "SELECT COUNT(*) FROM productos WHERE cod_producto = @c";

            SqlParameter p = new SqlParameter("@c", codigo);

            int cant = Convert.ToInt32(Conexion.EjecutarUnico(q, new SqlParameter[] { p }));
            return cant > 0;
        }

        // Inserta producto COMPLETO usando IDs
        public static int InsertarProducto(string cod, string desc, decimal costo, decimal precio,
                                           decimal ganancia, int idCategoria, int idSubcategoria, int idProveedor)
        {
            string q = @"
                INSERT INTO productos
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
                new SqlParameter("@cat", idCategoria),
                new SqlParameter("@subcat", idSubcategoria),
                new SqlParameter("@prov", idProveedor)
            };

            return Convert.ToInt32(Conexion.EjecutarUnico(q, p));
        }

        // Inserta stock inicial
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

        // Obtiene ID por código  
        public static int ObtenerIdPorCodigo(string cod)
        {
            string q = "SELECT id_producto FROM productos WHERE cod_producto = @c";
            SqlParameter p = new SqlParameter("@c", cod);

            object r = Conexion.EjecutarUnico(q, new SqlParameter[] { p });
            return r == null ? 0 : Convert.ToInt32(r);
        }

        // Crear producto desde compra → SOLO cuando el producto NO existía antes
        public static int CrearProductoDesdeCompra(string cod, string desc, decimal costo, decimal precio,
                                                   decimal ganancia, int idCategoria, int idSubcategoria,
                                                   int idProveedor, int stockInicial)
        {
            // Insertar el producto
            string q = @"
                INSERT INTO productos
                (cod_producto, prod_desc, precio, costo, ganancia, cod_categoria, cod_subcat, id_proveedor)
                OUTPUT INSERTED.id_producto
                VALUES (@cod, @desc, @precio, @costo, @ganancia, @cat, @subcat, @prov);

                INSERT INTO stock (id_producto, cantidad)
                VALUES (SCOPE_IDENTITY(), @stock);";

            SqlParameter[] pr =
            {
                new SqlParameter("@cod", cod),
                new SqlParameter("@desc", desc),
                new SqlParameter("@precio", precio),
                new SqlParameter("@costo", costo),
                new SqlParameter("@ganancia", ganancia),
                new SqlParameter("@cat", idCategoria),
                new SqlParameter("@subcat", idSubcategoria),
                new SqlParameter("@prov", idProveedor),
                new SqlParameter("@stock", stockInicial)
            };

            return Convert.ToInt32(Conexion.EjecutarUnico(q, pr));
        }

        public static int CrearProductoDesdeCompra2(string cod, string desc, decimal precio, int stockInicial)
        {
            string q = @"
        INSERT INTO productos (cod_producto, prod_desc, precio)
        OUTPUT INSERTED.id_producto
        VALUES (@cod, @desc, @precio);

        INSERT INTO stock (id_producto, cantidad)
        VALUES (SCOPE_IDENTITY(), @stock);";

            SqlParameter[] pr =
            {
        new SqlParameter("@cod", cod),
        new SqlParameter("@desc", desc),
        new SqlParameter("@precio", precio),
        new SqlParameter("@stock", stockInicial)
    };

            return Convert.ToInt32(Conexion.EjecutarUnico(q, pr));
        }

    }
}
