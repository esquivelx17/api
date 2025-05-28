using InventariosCore.Model;

public class Sesion
{
    public static int IdUsuarioActual { get; private set; }
    public static bool EsAdministrador { get; private set; }
    public static string UsuarioActual { get; private set; }
    public static Rol RolActual { get; private set; }
    public static List<Permiso> PermisosActuales { get; private set; } = new List<Permiso>();

    // Cambia IniciarSesion para recibir rol y permisos
    public static void IniciarSesion(Usuario usuario, Rol rol, List<Permiso> permisos)
    {
        IdUsuarioActual = usuario.IdUsuario;  // Asume que Usuario tiene IdUsuario
        UsuarioActual = usuario.Nickname;
        RolActual = rol;
        PermisosActuales = permisos;

        EsAdministrador = rol.NombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
    }

    public static void CerrarSesion()
    {
        IdUsuarioActual = 0;
        EsAdministrador = false;
        UsuarioActual = null;
        RolActual = null;
        PermisosActuales.Clear();
    }
}
