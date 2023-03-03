using APICQRS.Models;
using MediatR;

namespace APICQRS.Commands
{
    public class DeleteCategoria : IRequest<Categorias>
    {
        public int IdCategoria { get; set; }
    }
}
