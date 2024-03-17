using Application.Productos.Created;
using Application.Productos.Deleted;
using Application.Productos.Get;
using Application.Productos.GetById;
using Application.Productos.Update;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    public class ProductoController : Controller
    {
        private IMediator mediador;

        public ProductoController(IMediator mediator)
        {
            mediador = mediator;
        }

        [HttpGet]
        [Route("Producto")]
        [ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
        public Task<IActionResult> GetAllProducts()
        {
            var response = mediador.Send(new GetAllProductsQuery());
            return response;
        }

        [HttpPost]
        [Route("Producto")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        public Task<Producto> CreateProducto([Required]CreateProductCommand producto)
        {
            var response = mediador.Send(producto);
            return response;
        }

        [HttpDelete]
        [Route("Producto/{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public Task<IActionResult> DeleteProducto(Guid id)
        {
            var response = mediador.Send(new DeletedProductoCommand(id));
            return response;
        }

        [HttpGet]
        [Route("Producto/{id}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        public Task<Producto> GetByIdProducto(Guid id)
        {
            var response = mediador.Send(new GetProductByIdQuery(id));
            return response;
        }

        [HttpPut]
        [Route("Producto")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public Task<IActionResult> UpdateProducts(UpdateProductoCommand updateProducto)
        {
            var response = mediador.Send(updateProducto);
            return response;
        }
    }
}
