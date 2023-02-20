using MediatR;

namespace APICQRS.Queries
{
    public class GetCategoriaById : IRequest<Models.Categorias>
    {
        public int IdCategoria { get; set; }
    }
}
