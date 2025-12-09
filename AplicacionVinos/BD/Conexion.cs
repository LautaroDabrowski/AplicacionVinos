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
        private static readonly string cadena =
            "Data Source=LAPTOP-RISP0CDN;Initial Catalog=AppVinos;Integrated Security=True;Encrypt=False;";

        // ---------------------------
        //     Obtener DataTable
        // ---------------------------
        public static DataTable EjecutarConsulta(string consulta, params SqlParameter[] parametros)
        {
            var tabla = new DataTable();

            try
            {
                using (var cn = new SqlConnection(cadena))
                using (var cmd = new SqlCommand(consulta, cn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta:\n" + ex.Message);
            }

            return tabla;
        }

        // ----------------------------------
        //    INSERT / UPDATE / DELETE
        // ----------------------------------
        public static bool EjecutarABM(string consulta, params SqlParameter[] parametros)
        {
            try
            {
                using (var cn = new SqlConnection(cadena))
                using (var cmd = new SqlCommand(consulta, cn))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar operación:\n" + ex.Message);
                return false;
            }
        }

        // ----------------------------------
        //  Obtener valor único (Ej: último ID)
        // ----------------------------------
        public static object EjecutarUnico(string consulta, params SqlParameter[] parametros)
        {
            try
            {
                using (var cn = new SqlConnection(cadena))
                using (var cmd = new SqlCommand(consulta, cn))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    cn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar escalar:\n" + ex.Message);
                return null;
            }
        }

        // ----------------------------------
        //  Transacción (para ventas y compras)
        // ----------------------------------
        public static bool EjecutarTransaccion(List<SqlCommand> comandos)
        {
            using (var cn = new SqlConnection(cadena))
            {
                cn.Open();
                var trans = cn.BeginTransaction();

                try
                {
                    foreach (var cmd in comandos)
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error en transacción:\n" + ex.Message);
                    return false;
                }
            }
        }
        public static void CheckConnection()
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "No se pudo conectar a la base de datos.\n" +
                        "Por favor verifica que SQL Server esté iniciado y la configuración sea correcta.\n\n" +
                        $"Detalles: {ex.Message}",
                        "Error de conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    throw; // <- IMPORTANTE: relanzamos para detener la app si corresponde
                }
            }
        }

    }
}
