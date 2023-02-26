using APICQRS.Models;
using MediatR;

namespace APICQRS.Commands
{
    public class CreateCategoria : IRequest<Categorias>
    {
        public string? NombreCategoria { get; set; }
        public string? DescripcionCategoria { get; set;}
    }
}
