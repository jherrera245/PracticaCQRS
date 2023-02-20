using APICQRS.Data;
using APICQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICQRS.Queries
{
    public class GetCategoriaByIdHandler : IRequestHandler<GetCategoriaById, Categorias>
    {
        private readonly AppDbContext _context;

        public GetCategoriaByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categorias> Handle(
            GetCategoriaById request, 
            CancellationToken cancellationToken
        )
        {
            return await _context.Categorias.FirstOrDefaultAsync(
                categoria => categoria.IdCatgeoria == request.IdCategoria, 
                cancellationToken
            );
        }
    }
}
