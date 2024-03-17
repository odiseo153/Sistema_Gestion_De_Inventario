using Catalog.Application.Mappers;
using Core.Entities;
using Core.Repositories;

namespace Application.Productos.Created
{
    public class CreateProductoHandler : IRequestHandler<CreateProductCommand, Producto>
    {

        private IProductRepository productRepository;

        public CreateProductoHandler(IProductRepository product)
        {
            productRepository = product;
        }

        public async Task<Producto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validacion = new CreatedProductValidation().Validate(request);

            if (!validacion.IsValid) 
            {
                throw new Exception(validacion.Errors[0].ToString());
            }


            var producto = ProductMapper.mapper.Map<Producto>(request);
            var responseProducto =await productRepository.CreateProduct(producto);

            return responseProducto;
        }
    }
}
