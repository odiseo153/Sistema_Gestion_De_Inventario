

namespace Core.Repositories
{
    public interface IProductRepository
    {
        public Task<IActionResult> GetProducts();

        public Producto GetProductsById(Guid Id);

        public Task<Producto> CreateProduct(Producto product);

        public Task<IActionResult> UpdateProducts(Producto product, string motivo = "no se especificó el motivo");

        public Task<IActionResult> DeleteProducts(Guid Id);

    }

}


