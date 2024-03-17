using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alertas.Update
{
    public class UpdateAlertaHandler : IRequestHandler<UpdateAlertaCommand, Alerta>
    {

        private IAlertaRepository alertaRepository;

        public UpdateAlertaHandler(IAlertaRepository alerta)
        {
            alertaRepository = alerta;
        }

        public Task<Alerta> Handle(UpdateAlertaCommand request, CancellationToken cancellationToken)
        {
            var alerta = ProductMapper.mapper.Map<Alerta>(request);
            var alertaResponse = alertaRepository.UpdateAlertas(alerta);

            return alertaResponse;
        }
    }
}
