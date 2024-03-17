using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;


namespace Application.Productos.Get
{
    public class GetAllProductosHandler : IRequestHandler<GetAllProductsQuery, IActionResult>
    {
        private IProductRepository productRepository;
        private readonly IDistributedCache _cache;
        private readonly IOptions<MemoryCacheOptions> cacheOptions;


        public GetAllProductosHandler(IProductRepository product,IDistributedCache cache, IOptions<MemoryCacheOptions> cacheOptions)
        {
            productRepository = product;
            _cache = cache;
            this.cacheOptions = cacheOptions;
        }

        public async Task<IActionResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {




            return await productRepository.GetProducts();
        }

      }
}
