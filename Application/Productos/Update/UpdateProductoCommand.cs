using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Update
{
    public class UpdateProductoCommand : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public string? imagen { get; set; }

        public string? Categoria { get; set; }

    }
}
