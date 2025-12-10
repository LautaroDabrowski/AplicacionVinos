using AplicacionVinos.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AplicacionVinos.Config
{
    internal class ClienteAT
    {
        // Validar que no exista el mismo CUIT/CUIL
        public bool ExisteCuit(string cuit)
        {
            string consulta = "SELECT COUNT(*) FROM clientes WHERE cuit_cuil = @cuit";

            SqlParameter[] parametros = {
                new SqlParameter("@cuit", cuit)
            };

            object resultado = Conexion.EjecutarUnico(consulta, parametros);
            int cantidad = (resultado != null) ? Convert.ToInt32(resultado) : 0;

            return cantidad > 0;
        }

        // Agregar cliente usando clase Conexion
        public bool AgregarCliente(Cliente cli)
        {
            // Validar CUIT repetido
            if (!string.IsNullOrWhiteSpace(cli.CuitCuil) && ExisteCuit(cli.CuitCuil))
            {
                System.Windows.Forms.MessageBox.Show(
                    "El CUIT/CUIL ingresado ya existe en el sistema.",
                    "Dato duplicado",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);

                return false;
            }

            // Insert
            string consulta = @"
                INSERT INTO clientes 
                (cuit_cuil, nombre, apellido, razonsocial, tel, email, direccion, estado)
                VALUES
                (@cuit, @nombre, @apellido, @razon, @tel, @email, @direccion, @estado)
            ";

            SqlParameter[] parametros = {
                new SqlParameter("@cuit", cli.CuitCuil ?? (object)DBNull.Value),
                new SqlParameter("@nombre", cli.Nombre),
                new SqlParameter("@apellido", cli.Apellido),
                new SqlParameter("@razon", cli.RazonSocial ?? ""),
                new SqlParameter("@tel", cli.Telefono ?? ""),
                new SqlParameter("@email", cli.Email ?? ""),
                new SqlParameter("@direccion", cli.Direccion ?? ""),
                new SqlParameter("@estado", cli.Estado)
            };

            return Conexion.EjecutarABM(consulta, parametros);
        }

        // ---------------------- AGREGAR CLIENTE ----------------------
        public bool AgregarCli(Cliente cli)
        {
            // Verificar CUIT duplicado
            string check = "SELECT COUNT(*) FROM clientes WHERE cuit_cuil = @cuit";

            var existe = (int)Conexion.EjecutarUnico(check,
                new SqlParameter("@cuit", cli.CuitCuil));

            if (existe > 0)
            {
                System.Windows.Forms.MessageBox.Show("Ya existe un cliente con ese CUIT/CUIL");
                return false;
            }

            string query = @"INSERT INTO clientes
                    (cuit_cuil, nombre, apellido, razonsocial, tel, email, direccion, estado)
                     VALUES
                    (@cuit, @nombre, @apellido, @razon, @tel, @correo, @direccion, @estado)";

            return Conexion.EjecutarABM(query,
                new SqlParameter("@cuit", cli.CuitCuil),
                new SqlParameter("@nombre", cli.Nombre),
                new SqlParameter("@apellido", cli.Apellido),
                new SqlParameter("@razon", cli.RazonSocial),
                new SqlParameter("@tel", cli.Telefono),
                new SqlParameter("@correo", cli.Email),
                new SqlParameter("@direccion", cli.Direccion),
                new SqlParameter("@estado", cli.Estado)
            );
        }

        // ---------------------- BUSCAR CLIENTE ----------------------
        public DataTable BuscarClientes(string dni, string nombre, string apellido)
        {
            string query = @"SELECT id_cliente, cuit_cuil, nombre, apellido, razonsocial, tel, email, direccion, estado
                             FROM clientes
                             WHERE 1=1";

            var parametros = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(dni))
            {
                query += " AND cuit_cuil LIKE @dni";
                parametros.Add(new SqlParameter("@dni", "%" + dni + "%"));
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query += " AND (nombre LIKE @nom OR apellido LIKE @nom)";
                parametros.Add(new SqlParameter("@nom", "%" + nombre + "%"));
            }

            return Conexion.EjecutarTabla(query, parametros.ToArray());
        }

        // ---------------------- OBTENER CLIENTE POR ID ----------------------
        public Cliente ObtenerCliente(int id)
        {
            string query = "SELECT * FROM clientes WHERE id_cliente = @id";

            var tabla = Conexion.EjecutarTabla(query,
                new SqlParameter("@id", id));

            if (tabla.Rows.Count == 0)
                return null;

            var row = tabla.Rows[0];

            return new Cliente
            {
                id_cliente = Convert.ToInt32(row["id_cliente"]),
                CuitCuil = row["cuit_cuil"].ToString(),
                Nombre = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                RazonSocial = row["razonsocial"].ToString(),
                Telefono = row["tel"].ToString(),
                Email = row["email"].ToString(),
                Direccion = row["direccion"].ToString(),
                Estado = Convert.ToBoolean(row["estado"])
            };
        }

        // ---------------------- EDITAR CLIENTE ----------------------
        public bool EditarCliente(Cliente cli)
        {
            // verificar CUIT duplicado excepto su propio ID
            string check = @"SELECT COUNT(*) FROM clientes 
                             WHERE cuit_cuil = @cuit AND id_cliente <> @id";

            var repetido = (int)Conexion.EjecutarUnico(check,
                new SqlParameter("@cuit", cli.CuitCuil),
                new SqlParameter("@id", cli.id_cliente));

            if (repetido > 0)
            {
                System.Windows.Forms.MessageBox.Show("Ya existe otro cliente con ese CUIT/CUIL.");
                return false;
            }

            string query = @"UPDATE clientes SET
                                cuit_cuil = @cuit,
                                nombre = @nombre,
                                apellido = @apellido,
                                razonsocial = @razon,
                                tel = @tel,
                                email = @correo,
                                direccion = @direccion,
                                estado = @estado
                             WHERE id_cliente = @id";

            return Conexion.EjecutarABM(query,
                new SqlParameter("@cuit", cli.CuitCuil),
                new SqlParameter("@nombre", cli.Nombre),
                new SqlParameter("@apellido", cli.Apellido),
                new SqlParameter("@razon", cli.RazonSocial),
                new SqlParameter("@tel", cli.Telefono),
                new SqlParameter("@correo", cli.Email),
                new SqlParameter("@direccion", cli.Direccion),
                new SqlParameter("@estado", cli.Estado),
                new SqlParameter("@id", cli.id_cliente)
            );
        }
    }
}
