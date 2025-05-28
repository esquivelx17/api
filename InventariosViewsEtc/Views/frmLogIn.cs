using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventariosCore.Business;
using InventariosCore.Controllers;
using InvSis.Views;

namespace InvSis.Views
{
    public partial class frmLogIn : Form
    {
        private UsuariosController _usuariosController = new UsuariosController();
        private RolesController _rolesController = new RolesController();

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string usuarioIngresado = txtUsuario.Text.Trim();
                string contrasenaIngresada = txtContraseña.Text;

                var usuario = _usuariosController.AutenticarUsuario(usuarioIngresado, contrasenaIngresada);
                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos o inactivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var rol = _rolesController.ObtenerRoles(false)
                    .FirstOrDefault(r => r.IdRol == usuario.IdRol);

                if (rol == null)
                {
                    MessageBox.Show("El rol asignado al usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var permisos = _rolesController.ObtenerPermisosAsignados(rol.IdRol);

                Sesion.IniciarSesion(usuario, rol, permisos);

                MessageBox.Show($"Bienvenido {usuario.Nickname}.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
