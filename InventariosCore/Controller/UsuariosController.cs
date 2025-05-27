using System;
using System.Collections.Generic;
using InventariosCore.Data;
using InventariosCore.Model;
using System.Linq; // Add this directive at the top of the file


namespace InventariosCore.Controllers
{
    public class UsuariosController
    {
        private readonly UsuariosDataAccess _usuariosDA;
        private readonly PersonasDataAccess _personasDA;
        private readonly RolesDataAccess _rolesDA;
        private readonly RolesController _rolesController;

        public UsuariosController()
        {
            _usuariosDA = new UsuariosDataAccess();
            _personasDA = new PersonasDataAccess();
            _rolesDA = new RolesDataAccess();
            _rolesController = new RolesController();
        }

        public List<Usuario> ObtenerUsuariosOperadores()
        {
            // Obtener el rol "Operador"
            var rolOperador = _rolesController.GetRolPorNombre("Operador");
            if (rolOperador == null)
            {
                return new List<Usuario>(); // No existe el rol operador
            }

            // Obtener todos los usuarios activos
            var usuarios = _usuariosDA.ObtenerTodosLosUsuarios(true);

            // Filtrar los usuarios que tienen asignado el rol "Operador"

            // Replace the problematic line in the ObtenerUsuariosOperadores method with the following:
            var usuariosOperadores = usuarios.Where(u => u.Rol != null && u.Rol.IdRol == rolOperador.IdRol).ToList();


            return usuariosOperadores;
        }

        // Obtener lista de usuarios (activos por defecto)
        public List<Usuario> ObtenerUsuarios(bool soloActivos = true)
        {
            return _usuariosDA.ObtenerTodosLosUsuarios(soloActivos);
        }

        // Obtener usuario por id
        public Usuario? ObtenerUsuarioPorId(int idUsuario)
        {
            return _usuariosDA.ObtenerUsuarioPorId(idUsuario);
        }

        // Insertar nuevo usuario
        public int InsertarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            // Aquí puedes agregar validaciones extra si quieres

            return _usuariosDA.InsertarUsuario(usuario);
        }

        // Actualizar usuario existente
        public bool ActualizarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            // Validaciones antes de actualizar si es necesario

            return _usuariosDA.ActualizarUsuario(usuario);
        }

        // Eliminar usuario (lógico)
        public bool EliminarUsuario(int idUsuario)
        {
            return _usuariosDA.EliminarUsuario(idUsuario);
        }

        // Autenticar usuario
        public Usuario? AutenticarUsuario(string nickname, string contrasena)
        {
            return _usuariosDA.AutenticarUsuario(nickname, contrasena);
        }

        // Obtener todas las personas para llenar combo o grid (como usas en el formulario)
        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _personasDA.ObtenerTodasLasPersonas();
        }

        // Obtener todos los roles para llenar combo
        public List<Rol> ObtenerTodosLosRoles()
        {
            return _rolesDA.ObtenerTodosLosRoles();
        }
    }
}
