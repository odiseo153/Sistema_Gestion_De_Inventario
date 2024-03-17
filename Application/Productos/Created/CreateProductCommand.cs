using Core.Entities;
using MediatR;


namespace Application.Productos.Created
{
    public class CreateProductCommand : IRequest<Producto>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string imagen { get; set; }

        public string Categoria { get; set; }
    }
}
