using Application.Historial.GetAllHistorial;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HistorialController : Controller
    {
        private IMediator mediator;

        public HistorialController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Historial")]
        //[ProducesResponseType(typeof(Task<List<HistorialInventario>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistorial()
        {
            return await mediator.Send(new GetAllHistorialQuery());
        }
    }
}
