using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.GetById
{
    public class GetProductByIdQuery : IRequest<Producto>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid Id) 
        {
            this.Id = Id;        
        }
    }
}
