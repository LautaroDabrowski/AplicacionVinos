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
    internal class ProveedorAT
    {
        public string Razon { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public ProveedorAT() { }

        // VERIFICA SI YA EXISTE EN BD
        public bool ExisteEnBD()
        {
            object existe = Conexion.EjecutarUnico(
                "SELECT COUNT(*) FROM proveedores WHERE cuit_cuil = @cuit",
                new SqlParameter("@cuit", Cuit)
            );

            return Convert.ToInt32(existe) > 0;
        }

        // GUARDA UN PROVEEDOR EN LA BD
        public bool Guardar()
        {
            return Conexion.EjecutarABM(
                "INSERT INTO proveedores (cuit_cuil, razon_social, tel, email, direccion) " +
                "VALUES (@cuit, @razon, @tel, @mail, @dir)",
                new SqlParameter("@cuit", Cuit),
                new SqlParameter("@razon", Razon),
                new SqlParameter("@tel", Telefono),
                new SqlParameter("@mail", Email),
                new SqlParameter("@dir", Direccion)
            );
        }

        public static DataTable ObtenerLista()
        {
            string q = "SELECT id_proveedor, razon_social FROM proveedores ORDER BY razon_social";

            return Conexion.EjecutarTabla(q);
        }
    }
}

