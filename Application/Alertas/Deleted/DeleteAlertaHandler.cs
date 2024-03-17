using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alertas.Deleted
{
    public class DeleteAlertaHandler : IRequestHandler<DeleteAlertaCommand, IActionResult>
    {
        private IAlertaRepository alertaRepository;

        public DeleteAlertaHandler(IAlertaRepository alerta)
        {
            alertaRepository = alerta;
        }

        public async Task<IActionResult> Handle(DeleteAlertaCommand request, CancellationToken cancellationToken)
        {
            var alertaRespose = await alertaRepository.DeleteAlertas(request.Id);

            return alertaRespose;
        }
    }
}
