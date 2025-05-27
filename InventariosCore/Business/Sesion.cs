using InventariosCore.Model;

public class Sesion
{
    public static bool EsAdministrador { get; private set; }
    public static string UsuarioActual { get; private set; }
    public static Rol RolActual { get; private set; }
    public static List<Permiso> PermisosActuales { get; private set; } = new List<Permiso>();

    // Cambia IniciarSesion para recibir rol y permisos
    public static void IniciarSesion(Usuario usuario, Rol rol, List<Permiso> permisos)
    {
        UsuarioActual = usuario.Nickname;
        RolActual = rol;
        PermisosActuales = permisos;

        EsAdministrador = rol.NombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
    }

    public static void CerrarSesion()
    {
        EsAdministrador = false;
        UsuarioActual = null;
        RolActual = null;
        PermisosActuales.Clear();
    }
}

