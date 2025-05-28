using System.Collections.Generic;
using System.Linq;
using InventariosCore.Data;
using InventariosCore.Model;

namespace InventariosCore.Controllers
{
    public class RolesController
    {
        internal readonly RolesDataAccess _rolesDataAccess;
        internal readonly PermisosController _permisosController;
        internal readonly RolPermisoDataAccess _rolPermisoDataAccess;
        private readonly AuditoriaService _auditoriaService;

        public RolesController()
        {
            _rolesDataAccess = new RolesDataAccess();
            _permisosController = new PermisosController();
            _rolPermisoDataAccess = new RolPermisoDataAccess();
            _auditoriaService = new AuditoriaService();
        }

        public bool AgregarRol(Rol rol)
        {
            int id = _rolesDataAccess.InsertarRol(rol);
            bool exito = id > 0;
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Inserción", "Roles");
            }
            return exito;
        }

        public bool ActualizarRol(Rol rol)
        {
            bool exito = _rolesDataAccess.ActualizarRol(rol);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Actualización", "Roles");
            }
            return exito;
        }

        public Rol? GetRolPorNombre(string nombreRol)
        {
            var todos = ObtenerRoles(soloActivos: false);
            foreach (var rol in todos)
            {
                if (rol.NombreRol.Equals(nombreRol, System.StringComparison.OrdinalIgnoreCase))
                    return rol;
            }
            return null;
        }

        public List<Rol> ObtenerRoles(bool soloActivos = true)
        {
            return _rolesDataAccess.ObtenerTodosLosRoles(soloActivos);
        }

        public bool InhabilitarRolPorId(int idRol)
        {
            bool exito = _rolesDataAccess.EliminarRol(idRol);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("Inhabilitación", "Roles");
            }
            return exito;
        }

        // Asignar permiso a rol
        public bool AsignarPermisoARol(int idRol, int idPermiso)
        {
            bool exito = _rolPermisoDataAccess.InsertarRolPermiso(idRol, idPermiso);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("AsignaciónPermiso", "RolPermisos");
            }
            return exito;
        }

        // Eliminar permiso asignado a rol
        public bool RemoverPermisoDeRol(int idRol, int idPermiso)
        {
            bool exito = _rolPermisoDataAccess.EliminarRolPermiso(idRol, idPermiso);
            if (exito)
            {
                _auditoriaService.RegistrarAccion("RemociónPermiso", "RolPermisos");
            }
            return exito;
        }

        // Obtener permisos asignados a un rol
        public List<Permiso> ObtenerPermisosAsignados(int idRol)
        {
            return _rolPermisoDataAccess.ObtenerPermisosDeRol(idRol);
        }

        // Obtener permisos disponibles para asignar (todos menos los ya asignados)
        public List<Permiso> ObtenerPermisosDisponibles(int idRol)
        {
            var todos = _permisosController.ObtenerPermisos(soloActivos: true);
            var asignados = ObtenerPermisosAsignados(idRol);
            return todos.Where(p => !asignados.Any(a => a.IdPermiso == p.IdPermiso)).ToList();
        }
    }
}
