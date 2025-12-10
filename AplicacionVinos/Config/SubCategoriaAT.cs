using AplicacionVinos.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVinos.Config
{
    internal class SubCategoriaAT
    {
        // Obtener subcategorías por id de categoría
        public static DataTable ObtenerPorCategoria(int idCategoria)
        {
            string q = "SELECT id_subcategoria, subcategoria FROM subcategoria WHERE id_categoria = @id";
            return Conexion.EjecutarConsulta(q, new SqlParameter("@id", idCategoria));
        }

        // Ver si existe subcategoría dentro de una categoría
        public static bool Existe(string nombre, int idCategoria)
        {
            string q = @"SELECT id_subcategoria 
                         FROM subcategoria 
                         WHERE subcategoria = @nom AND id_categoria = @id";

            var r = Conexion.EjecutarUnico(q,
                new SqlParameter("@nom", nombre),
                new SqlParameter("@id", idCategoria));

            return r != null;
        }

        // Obtener ID
        public static int ObtenerId(string nombre, int idCategoria)
        {
            string q = @"SELECT id_subcategoria 
                         FROM subcategoria 
                         WHERE subcategoria = @nom AND id_categoria = @id";

            var r = Conexion.EjecutarUnico(q,
                new SqlParameter("@nom", nombre),
                new SqlParameter("@id", idCategoria));

            return (r == null) ? -1 : Convert.ToInt32(r);
        }

        // Insertar nueva
        public static int Insertar(string nombre, int idCategoria)
        {
            string q = @"
                INSERT INTO subcategoria (subcategoria, id_categoria)
                VALUES (@nom, @id);

                SELECT SCOPE_IDENTITY();";

            var r = Conexion.EjecutarUnico(q,
                new SqlParameter("@nom", nombre),
                new SqlParameter("@id", idCategoria));

            return Convert.ToInt32(r);
        }

        // Obtener o crear
        public static int ObtenerOCrear(string nombre, int idCategoria)
        {
            if (Existe(nombre, idCategoria))
                return ObtenerId(nombre, idCategoria);

            return Insertar(nombre, idCategoria);
        }
    }
}
