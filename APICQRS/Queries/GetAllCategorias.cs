using APICQRS.Models;
using MediatR;

namespace APICQRS.Queries
{
    public class GetAllCategorias : IRequest<IEnumerable<Categorias>>
    {

    }
}
