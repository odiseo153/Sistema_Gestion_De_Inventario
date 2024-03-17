

using System.ComponentModel.DataAnnotations;

namespace Core.Repositories
{
    public interface IUsuarioRepository
    {
        IActionResult Get();

        IActionResult CrearUsuario(Usuario user);

    }

}






