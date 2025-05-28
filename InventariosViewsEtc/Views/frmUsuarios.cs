using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventariosCore.Controllers;
using InventariosCore.Model;

namespace InvSis.Views
{
    public partial class frmUsuarios : Form
    {
        private UsuariosController _usuarioController;

        public frmUsuarios()
        {
            InitializeComponent();
            _usuarioController = new UsuariosController();

            PoblarComboEstatus(cbEstatus);
            PoblarComboEstatus(cbCambioEstatus);

            CargarPersonasEnDataGridView();
            CargarRolesEnDataGridView();
            CargarUsuariosEnGrid();

            dgvSeleccionUsuario.SelectionChanged += DgvSeleccionUsuario_SelectionChanged;
            SeguridadUI.BloquearBotonesSiEsLector(btGuardarCambios, btEliminar, btRegistroPersona, btAlta);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarPersonasEnDataGridView();
            CargarUsuariosEnGrid();
        }

        private void PoblarComboEstatus(ComboBox comboBox)
        {
            var list_estatus = new Dictionary<int, string>()
            {
                { 1, "Activo"},
                { 0, "Inactivo"},
            };
            comboBox.DataSource = new BindingSource(list_estatus, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.SelectedValue = 1;
        }

        private void CargarRolesEnCombo(ComboBox comboBox)
        {
            try
            {
                var roles = _usuarioController.ObtenerTodosLosRoles();

                comboBox.DataSource = null;    // Limpiar antes por si acaso
                comboBox.DataSource = roles;
                comboBox.DisplayMember = "NombreRol";   // Debe coincidir con propiedad real de Rol
                comboBox.ValueMember = "IdRol";       // Debe coincidir con propiedad real de Rol
                comboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPersonasEnDataGridView()
        {
            try
            {
                var personas = _usuarioController.ObtenerTodasLasPersonas();
                dgvSeleccionPersona.Rows.Clear();

                foreach (var p in personas)
                {
                    int index = dgvSeleccionPersona.Rows.Add(
                        p.NombreCompleto,
                        p.Edad.HasValue ? p.Edad.Value.ToString() : "",
                        p.Sexo,
                        p.Nacionalidad
                    );
                    // Guardamos el IdPersona en Tag para recuperarlo luego
                    dgvSeleccionPersona.Rows[index].Tag = p.IdPersona;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRolesEnDataGridView()
        {
            try
            {
                dgvSeleccionRol.Rows.Clear();
                var roles = _usuarioController.ObtenerTodosLosRoles();

                foreach (var rol in roles)
                {
                    int index = dgvSeleccionRol.Rows.Add(
                        rol.NombreRol,
                        rol.Estatus == 1 ? "Activo" : "Inactivo"
                    );
                    dgvSeleccionRol.Rows[index].Tag = rol.IdRol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuariosEnGrid()
        {
            try
            {
                dgvSeleccionUsuario.Rows.Clear();

                // Pasa false para obtener activos e inactivos
                var usuarios = _usuarioController.ObtenerUsuarios(soloActivos: false);

                foreach (var u in usuarios)
                {
                    int index = dgvSeleccionUsuario.Rows.Add(
                        u.Rol.NombreRol,
                        u.Nickname,
                        "********",  // No mostrar contraseña real
                        u.Estatus == 1 ? "Activo" : u.Estatus == 0 ? "Inactivo" : "Otro",
                        u.Persona.NombreCompleto
                    );
                    dgvSeleccionUsuario.Rows[index].Tag = u.IdUsuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DatosVacios()
        {
            return string.IsNullOrWhiteSpace(txtNickname.Text)
                || string.IsNullOrWhiteSpace(txtContraseña.Text)
                || cbEstatus.SelectedIndex == -1
                || dgvSeleccionPersona.SelectedRows.Count == 0;
        }

        private int ObtenerIdPersonaSeleccionada()
        {
            if (dgvSeleccionPersona.SelectedRows.Count == 0)
                throw new InvalidOperationException("No hay persona seleccionada.");

            return (int)dgvSeleccionPersona.SelectedRows[0].Tag;
        }

        private int ObtenerIdUsuarioSeleccionado()
        {
            if (dgvSeleccionUsuario.SelectedRows.Count == 0)
                throw new InvalidOperationException("No hay usuario seleccionado.");

            return (int)dgvSeleccionUsuario.SelectedRows[0].Tag;
        }

        private void LimpiarCamposAlta()
        {
            txtNickname.Clear();
            txtContraseña.Clear();
            cbEstatus.SelectedValue = 1;

            dgvSeleccionPersona.ClearSelection();
            dgvSeleccionRol.ClearSelection();
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNickname.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                cbEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSeleccionPersona.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una persona.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSeleccionRol.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPersona = (int)dgvSeleccionPersona.SelectedRows[0].Tag;
                int idRol = (int)dgvSeleccionRol.SelectedRows[0].Tag;

                var usuario = new Usuario
                {
                    Nickname = txtNickname.Text.Trim(),
                    Contraseña = txtContraseña.Text.Trim(),
                    Estatus = (int)cbEstatus.SelectedValue,
                    IdPersona = idPersona,
                    IdRol = idRol
                };

                int nuevoId = _usuarioController.InsertarUsuario(usuario);

                MessageBox.Show($"Usuario guardado correctamente con ID {nuevoId}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuariosEnGrid();
                LimpiarCamposAlta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dgvSeleccionUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCambioNickname.Text) ||
                string.IsNullOrWhiteSpace(txtCambioContraseña.Text) ||
                cbCambioEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos de edición.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCambioRol.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un nuevo rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idUsuario = (int)dgvSeleccionUsuario.SelectedRows[0].Tag;
                var usuario = _usuarioController.ObtenerUsuarioPorId(idUsuario);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualizar datos con los controles
                usuario.Nickname = txtCambioNickname.Text.Trim();
                usuario.Contraseña = txtCambioContraseña.Text.Trim();

                // Forzar estatus activo
                usuario.Estatus = 1;

                // Obtener IdRol del rol seleccionado en dgvCambioRol
                int nuevoIdRol = (int)dgvCambioRol.SelectedRows[0].Tag;
                usuario.IdRol = nuevoIdRol;

                bool resultado = _usuarioController.ActualizarUsuario(usuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuariosEnGrid();
                    LimpiarCamposEdicionUsuario();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSeleccionUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro que desea eliminar (desactivar) el usuario seleccionado?",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                int idUsuario = (int)dgvSeleccionUsuario.SelectedRows[0].Tag;
                bool resultado = _usuarioController.EliminarUsuario(idUsuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuariosEnGrid();
                    LimpiarCamposEdicionUsuario();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRegistroPersona_Click(object sender, EventArgs e)
        {
            var formPersona = new frmPersona();
            formPersona.ShowDialog();

            // Refrescar personas tras posible nueva
            CargarPersonasEnDataGridView();
        }

        private void lblRol_Click(object sender, EventArgs e)
        {

        }


        private void DgvSeleccionPersona_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeleccionPersona.SelectedRows.Count == 0)
            {
                // No hay selección, limpia campos si quieres
                // Por ejemplo: txtNickname.Clear();
                return;
            }

            // Obtener datos de la persona seleccionada
            var fila = dgvSeleccionPersona.SelectedRows[0];

            // Si quieres mostrar el nombre completo en un label o textbox, puedes hacerlo aquí:
            string nombrePersona = fila.Cells["Nombre"].Value?.ToString() ?? "";

            // Ejemplo: podrías mostrarlo en una etiqueta o simplemente usarlo para algo
            // lblPersonaSeleccionada.Text = nombrePersona;

            // Si necesitas hacer algo más, ponlo aquí
        }

        private void DgvSeleccionRol_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeleccionRol.SelectedRows.Count == 0)
            {
                // Limpia o deshabilita controles si es necesario
                return;
            }

            // Obtener datos del rol seleccionado
            var fila = dgvSeleccionRol.SelectedRows[0];

            string nombreRol = fila.Cells["NombrePermiso"].Value?.ToString() ?? "";

            // Ejemplo: mostrar nombre en un label o textbox
            // lblRolSeleccionado.Text = nombreRol;

            // Más acciones según lo que necesites hacer
        }

        private void DgvSeleccionUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeleccionUsuario.SelectedRows.Count == 0)
            {
                LimpiarCamposEdicionUsuario();
                return;
            }

            int idUsuario = (int)dgvSeleccionUsuario.SelectedRows[0].Tag;
            var usuario = _usuarioController.ObtenerUsuarioPorId(idUsuario);

            if (usuario == null)
            {
                LimpiarCamposEdicionUsuario();
                return;
            }

            // Llenar los campos de edición
            txtCambioNickname.Text = usuario.Nickname;
            txtCambioContraseña.Text = usuario.Contraseña;
            cbCambioEstatus.SelectedValue = usuario.Estatus;

            // Cargar roles excepto el actual en dgvCambioRol
            CargarRolesExceptoActual(usuario.IdRol);
        }

        private void LimpiarCamposEdicionUsuario()
        {
            txtCambioNickname.Clear();
            txtCambioContraseña.Clear();
            cbCambioEstatus.SelectedIndex = -1;
            dgvCambioRol.Rows.Clear();
        }

        private void CargarRolesExceptoActual(int idRolActual)
        {
            dgvCambioRol.Rows.Clear();

            var roles = _usuarioController.ObtenerTodosLosRoles();

            foreach (var rol in roles)
            {
                if (rol.IdRol == idRolActual)
                    continue;  // Salta el rol actual

                int index = dgvCambioRol.Rows.Add(rol.NombreRol, rol.Estatus == 1 ? "Activo" : "Inactivo");
                dgvCambioRol.Rows[index].Tag = rol.IdRol;
            }
        }



    }
}
