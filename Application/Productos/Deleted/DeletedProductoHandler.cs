using Catalog.Application.Mappers;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Application.Productos.Deleted
{
    public class DeletedProductoHandler : IRequestHandler<DeletedProductoCommand,IActionResult>
    {

        private IProductRepository productRepository;

        public DeletedProductoHandler(IProductRepository product)
        {
            productRepository = product;
        }

        public async Task<IActionResult> Handle(DeletedProductoCommand request, CancellationToken cancellationToken)
        {
            var responseProducto =await productRepository.DeleteProducts(request.Id);
            return responseProducto;
        }
    }
}
