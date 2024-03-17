using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Created
{
    public class CreatedUsuarioHandler : IRequestHandler<CreatedUsuarioCommand, IActionResult>
    {
        private IUsuarioRepository usuarioRepository;

        public CreatedUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<IActionResult> Handle(CreatedUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validacion = new CreatedUsuarioValidation().Validate(request);

            if (!validacion.IsValid) 
            {
                throw new Exception(validacion.Errors[0].ToString());
            }


            var usuario = ProductMapper.mapper.Map<Usuario>(request);
            var usuarioResponse = usuarioRepository.CrearUsuario(usuario);

            return usuarioResponse;
        }
    }
}
