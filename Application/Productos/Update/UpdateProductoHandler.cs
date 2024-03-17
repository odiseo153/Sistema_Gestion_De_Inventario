

namespace Application.Productos.Update
{
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand,IActionResult>
    {
        private IProductRepository productRepository;

        public UpdateProductoHandler(IProductRepository product)
        {
            productRepository = product;
        }

        public Task<IActionResult> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = ProductMapper.mapper.Map<Producto>(request);
            var productoResponse = productRepository.UpdateProducts(producto);

            return productoResponse;

        }
    }
}
