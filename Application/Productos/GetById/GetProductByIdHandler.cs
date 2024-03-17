


namespace Application.Productos.GetById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Producto>
    {
        private IProductRepository productRepository;

        public GetProductByIdHandler(IProductRepository product)
        {
            productRepository = product;
        }

        public async Task<Producto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return productRepository.GetProductsById(request.Id);
        }
    }
}

