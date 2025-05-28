using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;
using System.Linq;

namespace InventariosCore.Controllers
{
    public class UsuariosController
    {
        private readonly UsuariosDataAccess _usuariosDA;
        private readonly PersonasDataAccess _personasDA;
        private readonly RolesDataAccess _rolesDA;
        private readonly RolesController _rolesController;
        private readonly AuditoriaService _auditoriaService;

        public UsuariosController()
        {
            _usuariosDA = new UsuariosDataAccess();
            _personasDA = new PersonasDataAccess();
            _rolesDA = new RolesDataAccess();
            _rolesController = new RolesController();
            _auditoriaService = new AuditoriaService();
        }

        public List<Usuario> ObtenerUsuariosOperadores()
        {
            var rolOperador = _rolesController.GetRolPorNombre("Operador");
            if (rolOperador == null)
            {
                return new List<Usuario>();
            }

            var usuarios = _usuariosDA.ObtenerTodosLosUsuarios(true);

            var usuariosOperadores = usuarios.Where(u => u.Rol != null && u.Rol.IdRol == rolOperador.IdRol).ToList();

            return usuariosOperadores;
        }

        public List<Usuario> ObtenerUsuarios(bool soloActivos = true)
        {
            return _usuariosDA.ObtenerTodosLosUsuarios(soloActivos);
        }

        public Usuario? ObtenerUsuarioPorId(int idUsuario)
        {
            return _usuariosDA.ObtenerUsuarioPorId(idUsuario);
        }

        public int InsertarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            int id = _usuariosDA.InsertarUsuario(usuario);

            if (id > 0)
            {
                _auditoriaService.RegistrarAccion("Inserción", "Usuarios");
            }

            return id;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            bool resultado = _usuariosDA.ActualizarUsuario(usuario);

            if (resultado)
            {
                _auditoriaService.RegistrarAccion("Actualización", "Usuarios");
            }

            return resultado;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            bool resultado = _usuariosDA.EliminarUsuario(idUsuario);

            if (resultado)
            {
                _auditoriaService.RegistrarAccion("Eliminación", "Usuarios");
            }

            return resultado;
        }

        public Usuario? AutenticarUsuario(string nickname, string contrasena)
        {
            return _usuariosDA.AutenticarUsuario(nickname, contrasena);
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _personasDA.ObtenerTodasLasPersonas();
        }

        public List<Rol> ObtenerTodosLosRoles()
        {
            return _rolesDA.ObtenerTodosLosRoles();
        }
    }
}
