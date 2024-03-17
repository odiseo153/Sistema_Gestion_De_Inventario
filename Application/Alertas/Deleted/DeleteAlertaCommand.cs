using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alertas.Deleted
{
    public class DeleteAlertaCommand : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public DeleteAlertaCommand(Guid id)
        {
            Id = id;
        }
    }
}
