

namespace Application.Usuarios.GetAllUsuarios
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioCommand,IActionResult>
    {
        private IUsuarioRepository usuarioRepository;

        public GetAllUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<IActionResult> Handle(GetAllUsuarioCommand request, CancellationToken cancellationToken)
        {
            return usuarioRepository.Get();
        }
    }
}
