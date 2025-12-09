using AplicacionVinos.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVinos.Config
{
    internal class UsuarioAT
    {
        public static bool HayUsuarios()
        {
            string consulta = "SELECT COUNT(*) FROM usuario_login";

            object result = Conexion.EjecutarUnico(consulta);

            int cantidad = Convert.ToInt32(result);

            return cantidad > 0; // true si hay usuarios, false si está vacío
        }
        public static void CrearUsuarioAdmin()
        {
            // 1. Nos aseguramos de que exista el tipo Administrador
            string qTipo = "IF NOT EXISTS (SELECT 1 FROM usuarios_tipo WHERE descripcion = 'Administrador') " +
                           "INSERT INTO usuarios_tipo (descripcion) VALUES ('Administrador')";

            Conexion.EjecutarABM(qTipo);

            // 2. Buscamos el ID del tipo
            string qGetTipo = "SELECT id_usuario_tipo FROM usuarios_tipo WHERE descripcion = 'Administrador'";
            int idTipo = Convert.ToInt32(Conexion.EjecutarUnico(qGetTipo));

            // 3. Insertamos usuario admin
            string qUser =
                "INSERT INTO usuario_login (username, contrasenia, id_tipo) " +
                "VALUES ('admin', 'admin', @tipo)";

            SqlParameter param = new SqlParameter("@tipo", idTipo);

            Conexion.EjecutarABM(qUser, param);
        }

        public static (bool Exito, int Tipo) ValidarLogin(string user, string pass)
        {
            string consulta =
                "SELECT id_tipo FROM usuario_login " +
                "WHERE username = @u AND contrasenia = @c";

            SqlParameter[] p =
            {
              new SqlParameter("@u", user),
              new SqlParameter("@c", pass)
            };

            object result = Conexion.EjecutarUnico(consulta, p);

            if (result == null || result == DBNull.Value)
                return (false, 0); // No existe

            return (true, Convert.ToInt32(result));
        }

    }
}

