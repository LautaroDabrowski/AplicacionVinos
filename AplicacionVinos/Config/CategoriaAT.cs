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
    internal class CategoriaAT
    {
        // Obtener todas las categorías
        public static DataTable ObtenerTodas()
        {
            string q = "SELECT id_categoria, categoria FROM categorias ORDER BY categoria";
            return Conexion.EjecutarConsulta(q);
        }

        // Ver si existe la categoría
        public static bool Existe(string nombre)
        {
            string q = "SELECT id_categoria FROM categorias WHERE categoria = @nom";
            var r = Conexion.EjecutarUnico(q, new SqlParameter("@nom", nombre));
            return r != null; // si trae algo, existe
        }

        // Obtener ID de categoría
        public static int ObtenerId(string nombre)
        {
            string q = "SELECT id_categoria FROM categorias WHERE categoria = @nom";
            var r = Conexion.EjecutarUnico(q, new SqlParameter("@nom", nombre));
            return (r == null) ? -1 : Convert.ToInt32(r);
        }

        // Insertar categoría si no existe
        public static int Insertar(string nombre)
        {
            string q = @"
                INSERT INTO categorias (categoria)
                VALUES (@nom);

                SELECT SCOPE_IDENTITY();";

            var r = Conexion.EjecutarUnico(q, new SqlParameter("@nom", nombre));
            return Convert.ToInt32(r);
        }

        // Obtener ID o crearlo si no existe
        public static int ObtenerOCrear(string nombre)
        {
            if (Existe(nombre))
                return ObtenerId(nombre);

            return Insertar(nombre);
        }
    }
}
