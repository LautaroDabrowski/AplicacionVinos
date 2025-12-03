using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionVinos.BD
{
    internal class Conexion
    {
        private static string cadena =
           "Data Source=BRENDA\\SQLEXPRESS;Initial Catalog=BDAtalayaPoo;Integrated Security=True;Encrypt=False;";

        public static SqlDataReader Leer(string consulta, params SqlParameter[] parametros)
        {
            try
            {
                var cn = new SqlConnection(cadena);
                var cmd = new SqlCommand(consulta, cn);
                if (parametros != null && parametros.Length > 0)
                    cmd.Parameters.AddRange(parametros);

                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer de la base:\n" + ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool ABM(string consulta, params SqlParameter[] parametros)
        {
            using (var cn = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(consulta, cn))
            {
                if (parametros != null && parametros.Length > 0)
                    cmd.Parameters.AddRange(parametros);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la operación:\n" + ex.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public void Abrir()
        {
            if (ConexionBD.State == ConnectionState.Closed)
                ConexionBD.Open();
        }

        public void Cerrar()
        {
            if (ConexionBD.State == ConnectionState.Open)
                ConexionBD.Close();
        }
    }
}
