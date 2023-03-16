using APICQRS.Models;
using FluentValidation;

namespace APICQRS.Validations
{
    public class CategoriasValidator : AbstractValidator<Categorias>
    {
        public CategoriasValidator() {
            //no nulo, minimo de caracteres 10, maximo de caracteres 80
            RuleFor(categoria => categoria.NombreCategoria)
            .NotNull().NotEmpty().MinimumLength(10).MaximumLength(80)
            .WithMessage("Por favor ingresa el nombre de la categoria");
            
            //pude ser nulo
            RuleFor(categoria => categoria.DescripcionCategoria).Empty();
        }
    }

}