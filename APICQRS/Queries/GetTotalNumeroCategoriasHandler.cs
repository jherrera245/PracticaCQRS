using APICQRS.Data;
using APICQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICQRS.Queries
{
    public class GetTotalNumeroCategoriasHandler : IRequestHandler<GetTotalNumeroCategorias, int>
    {
        private readonly AppDbContext _context;

        public GetTotalNumeroCategoriasHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetTotalNumeroCategorias request, CancellationToken cancellationToken)
        {
            var totalRecords = await _context.Categorias.CountAsync();
            return totalRecords;
        }
    }
}
