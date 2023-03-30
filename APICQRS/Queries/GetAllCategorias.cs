using APICQRS.Filters;
using APICQRS.Models;
using MediatR;

namespace APICQRS.Queries
{
    public class GetAllCategorias : IRequest<IEnumerable<Categorias>>
    {
        //Referecia al clase PaginationFilter
        public PaginationFilter Pagination { get; set; }
    }
}
