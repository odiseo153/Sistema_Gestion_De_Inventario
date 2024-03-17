using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alertas.GetAllAlertas
{
    public class GetAllAlertasHandler : IRequestHandler<GetAllAlertasQuery, IActionResult>
    {
        private IAlertaRepository alertaRepository;

        public GetAllAlertasHandler(IAlertaRepository alerta)
        {
            alertaRepository = alerta;
        }

        public async Task<IActionResult> Handle(GetAllAlertasQuery request, CancellationToken cancellationToken)
        {
            return await alertaRepository.GetAllAlerta();
        }
    }
}
