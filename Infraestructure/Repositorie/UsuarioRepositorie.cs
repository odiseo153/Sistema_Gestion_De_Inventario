

using Microsoft.AspNetCore.Http;

namespace Infraestructure.Repositorie
{
    public class UsuarioRepositorie : IUsuarioRepository
    {
        private SistemaGestionContext context;

        public UsuarioRepositorie(SistemaGestionContext context)
        {
            this.context = context;
        }

        public IActionResult CrearUsuario(Usuario user)
        {
            context.Usuarios.Add(user);
            context.SaveChanges();

            return new JsonResult(new
            {
                message = "Usuario Creado con exito",
                code = StatusCodes.Status201Created
            });
        }

        public IActionResult Get()
        {
            return new JsonResult(context.Usuarios.Select(x => new {
            nombre = x.Nombre,
            Rol = x.Rol,
            Id = x.Id,
            })) ; 
        }

        public IActionResult Login(string nombre, string clave)
        {
            throw new NotImplementedException();
        }
    }
}
