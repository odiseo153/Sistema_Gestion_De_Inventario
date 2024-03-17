using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Created
{
    public class CreatedProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreatedProductValidation()
        {
            RuleFor(x => x.Descripcion)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.imagen)
                .MinimumLength(10)
                .NotEmpty();

            RuleFor(x => x.Nombre)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.Precio)
                .Must(x => x > 2)
                .NotEmpty();

        }
    }
}
