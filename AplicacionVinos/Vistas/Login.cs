using AplicacionVinos.BD;
using AplicacionVinos.Config;
using System;
using AplicacionVinos.Validaciones;
using System.Windows.Forms;

namespace AplicacionVinos.Vistas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            Validar.DeshabilitarShortcuts(this);
            Validar.DeshabilitarShortcutsEnControles(this);

            

            // Enter → botón iniciar
            this.AcceptButton = btn_InicioSesion;

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_Contrasenia.UseSystemPasswordChar = true;

            try
            {
                Conexion.CheckConnection();
            }
            catch
            {
                this.Close();
            }

            try
            {
                // Si NO hay usuarios, crear admin
                if (!UsuarioAT.HayUsuarios())
                {
                    UsuarioAT.CrearUsuarioAdmin();

                    MessageBox.Show(
                        "La aplicación se inició por primera vez.\n\n" +
                        "Se creó el usuario inicial:\n" +
                        "Usuario: admin\nContraseña: admin",
                        "Usuario administrador creado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al inicializar la aplicación:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_InicioSesion_Click(object sender, EventArgs e)
        {
            string user = txt_Usuario.Text.Trim();
            string pass = txt_Contrasenia.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Complete ambos campos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = UsuarioAT.ValidarLogin(user, pass);

            if (!resultado.Exito)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tipo = resultado.Tipo; // Admin = 1, Empleado = 2, etc

            // Guardamos el tipo de usuario para usar en los permisos
            Sesiones.TipoUsuario = tipo;
            Sesiones.UsuarioActual = user;

            // Abrimos el inicio como formulario principal
            Inicio frm = new Inicio();

            this.Hide(); // oculto login

            frm.FormClosed += (s, args) => this.Close(); // CUANDO cierre Inicio, cerrar Login también

            frm.Show();
        }
    }
}
