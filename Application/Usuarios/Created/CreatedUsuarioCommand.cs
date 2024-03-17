using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Created
{
    public class CreatedUsuarioCommand : IRequest<IActionResult>
    {
        public enum Estado
        {
            Admin,
            Encargado,
            Cabo
        }

        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        [EnumDataType(typeof(Estado))]
        public Estado? Rol { get; set; }
    }
}
