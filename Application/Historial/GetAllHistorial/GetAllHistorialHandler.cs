


namespace Application.Historial.GetAllHistorial
{
    public class GetAllHistorialHandler : IRequestHandler<GetAllHistorialQuery, IActionResult>
    {

        private IHistorialInventarioRepository historialRepository;

        public GetAllHistorialHandler(IHistorialInventarioRepository historial)
        {
            historialRepository = historial;
        }


        public async Task<IActionResult> Handle(GetAllHistorialQuery request, CancellationToken cancellationToken)
        {
            return await historialRepository.GetAllHistorial();
        }
    }
}
