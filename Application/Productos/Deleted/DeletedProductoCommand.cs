using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Deleted
{
    public class DeletedProductoCommand : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public DeletedProductoCommand(Guid id) 
        {        
            Id = id;
        }

    }
}
