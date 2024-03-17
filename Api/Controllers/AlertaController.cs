using Application.Alertas.Created;
using Application.Alertas.Deleted;
using Application.Alertas.GetAllAlertas;
using Application.Alertas.Update;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AlertaController : Controller
    {
        private IMediator mediador;

        public AlertaController(IMediator mediator)
        {
            mediador = mediator;
        }

        [HttpGet]
        [Route("Alerta")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get_Alertas()
        {
            return await mediador.Send(new GetAllAlertasQuery());
        }

        [HttpPost]
        [Route("Alerta")]
        [ProducesResponseType(typeof(Alerta), StatusCodes.Status200OK)]
        public async Task<Alerta> CreateAlerta(CreatedAlertaCommand alerta)
        {
            return await mediador.Send(alerta);
        }

        [HttpDelete]
        [Route("Alerta")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAlerta(Guid id)
        {
            return await mediador.Send(new DeleteAlertaCommand(id));
        }

        [HttpPut]
        [Route("Alerta")]
        [ProducesResponseType(typeof(Alerta), StatusCodes.Status200OK)]
        public async Task<Alerta> UpdateAlerta(UpdateAlertaCommand alerta)
        {
            return await mediador.Send(alerta);
        }
    }
}
