using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InvSis.Views
{
    public partial class frmMDI : Form
    {
        private Dictionary<string, Form> openForms = new Dictionary<string, Form>();

        public frmMDI()
        {
            InitializeComponent();
            // Configurar permisos según el rol actual
            ConfigurarPermisosBotones();
        }

        private void ConfigurarPermisosBotones()
        {
            string rol = Sesion.RolActual.NombreRol;  // Access the NombreRol property of the Rol object

            // Por defecto, deshabilitamos todos los botones:
            btnAdmUsr.Enabled = false;
            btnGesRoles.Enabled = false;
            btnRepAud.Enabled = false;
            btnAPI.Enabled = false;
            btnRegMov.Enabled = false;
            btnRepInv.Enabled = false;
            btnGestionarPermisos.Enabled = false;

            switch (rol)
            {
                case "Administrador":
                    // Todo habilitado
                    btnAdmUsr.Enabled = true;
                    btnGesRoles.Enabled = true;
                    btnRepAud.Enabled = true;
                    btnAPI.Enabled = true;
                    btnRegMov.Enabled = true;
                    btnRepInv.Enabled = true;
                    btnGestionarPermisos.Enabled = true;
                    break;

                case "Lector":
                    // Puede abrir todo pero sin modificar (bloqueo de botones dentro de formularios)
                    btnAdmUsr.Enabled = true;
                    btnGesRoles.Enabled = true;
                    btnRepAud.Enabled = true;
                    btnAPI.Enabled = true;
                    btnRegMov.Enabled = true;
                    btnRepInv.Enabled = true;
                    btnGestionarPermisos.Enabled = true;
                    break;

                case "Operador":
                    // Solo puede acceder a Registrar Movimientos
                    btnRegMov.Enabled = true;
                    break;

                case "Seguridad":
                    // Solo puede acceder a Reportes de Auditoría
                    btnRepAud.Enabled = true;
                    break;

                case "Autorizador":
                    // Administrar Productos y Registrar Movimientos
                    btnAdmProd.Enabled = true;
                    btnRegMov.Enabled = true;
                    break;

                default:
                    // Sin acceso a nada
                    break;
            }
        }

        private void EjecutarConWaitCursor(Action accion)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                accion();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void OpenFormInPanel(string formName)
        {
            Form formToShow;

            // Verificar si la ventana ya existe
            if (openForms.ContainsKey(formName))
            {
                formToShow = openForms[formName];
                formToShow.BringToFront();
            }
            else
            {
                formToShow = CrearForma(formName);
                if (formToShow == null)
                    return;

                formToShow.TopLevel = false;
                formToShow.FormBorderStyle = FormBorderStyle.None;
                formToShow.Dock = DockStyle.Fill;

                splitMDI.Panel2.Controls.Add(formToShow);
                openForms.Add(formName, formToShow);
                formToShow.Show();
                formToShow.BringToFront();

                // Aquí puedes enviar el rol para que el formulario controle internamente botones específicos
                if (formToShow is IFormConPermisos formConPermisos)
                {
                    formConPermisos.SetRolUsuario(Sesion.RolActual.NombreRol);
                }
            }
        }

        private Form CrearForma(string formName)
        {
            switch (formName)
            {
                case "frmAdminProd":
                    return new frmAdminProd();
                case "frmGestionRoles":
                    return new frmGestionRoles();
                case "frmGestrionPermisos":
                    return new frmGestrionPermisos();
                case "frmVReportesAuditoria":
                    return new frmVReportesAuditoria();
                case "frmUsuarios":
                    return new frmUsuarios();
                case "frmApiInicio":  // <-- Cambiado aquí desde frmRepAPI
                    return new frmApiInicio();
                case "frmRegMov":
                    return new frmRegMov();
                case "frmRepInv":
                    return new frmRepInv();
                default:
                    MessageBox.Show($"No se reconoce el formulario: {formName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }


        private void btnAdmUsr_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmUsuarios"));
        }

        private void btnGesRoles_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmGestionRoles"));
        }

        private void btnRepAud_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmVReportesAuditoria"));
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmApiInicio"));
        }

        private void btnRegMov_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmRegMov"));
        }

        private void btnRepInv_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmRepInv"));
        }

        private void btnGestionarPermisos_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmGestrionPermisos"));
        }

        private void btnAdmProd_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() => OpenFormInPanel("frmAdminProd"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() =>
            {
                foreach (var form in openForms.Values)
                {
                    form.Close();
                    form.Dispose();
                }
                openForms.Clear();
            });
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            EjecutarConWaitCursor(() =>
            {
                var result = MessageBox.Show(
                    $"¿Está seguro que desea cerrar la sesión de {Sesion.UsuarioActual}?",
                    "Cerrar Sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (var form in openForms.Values)
                    {
                        form.Close();
                        form.Dispose();
                    }
                    openForms.Clear();

                    Sesion.CerrarSesion();

                    var login = new frmLogIn();
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        ConfigurarPermisosBotones();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            });
        }
    }

    // Interfaz para que los formularios reciban el rol actual y puedan bloquear botones internos
    public interface IFormConPermisos
    {
        void SetRolUsuario(string rol);
    }
}
