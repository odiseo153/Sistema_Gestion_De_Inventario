using FluentValidation;

namespace Application.Usuarios.Created
{
    public class CreatedUsuarioValidation : AbstractValidator<CreatedUsuarioCommand>
    {
        public CreatedUsuarioValidation() 
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2);

            RuleFor(x => x.Rol)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Contraseña)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);
                
        }
    }
}
