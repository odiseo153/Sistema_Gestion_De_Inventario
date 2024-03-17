using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alertas.Created
{
    public class CreatedAlertaHandler : IRequestHandler<CreatedAlertaCommand, Alerta>
    {
        private IAlertaRepository alertaRepository;

        public CreatedAlertaHandler(IAlertaRepository alerta)
        {
            alertaRepository = alerta;
        }

        public Task<Alerta> Handle(CreatedAlertaCommand request, CancellationToken cancellationToken)
        {
            var alerta = ProductMapper.mapper.Map<Alerta>(request);
            var alertaResponse = alertaRepository.CreateAlerta(alerta);

            return alertaResponse;
        }
    }
}
