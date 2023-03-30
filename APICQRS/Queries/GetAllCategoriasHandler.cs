using APICQRS.Data;
using APICQRS.Filters;
using APICQRS.Models;
using APICQRS.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICQRS.Queries
{
    public class GetAllCategoriasHandler : IRequestHandler<GetAllCategorias, IEnumerable<Categorias>>
    {
        //objeto AppDbContext para conexion a base de datos
        private readonly AppDbContext _context;
        // constructor
        public GetAllCategoriasHandler(AppDbContext context)
        {
            _context = context;
        }

        //metodo responsables de las peticiones asincronas y devolver la lista
        //de categorias 
        public async Task<IEnumerable<Categorias>> Handle(
            GetAllCategorias request, CancellationToken cancellationToken
        )
        {
            var listaCategorias = await _context.Categorias
                .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
                .Take(request.Pagination.PageSize)
                .ToListAsync();

            if (listaCategorias == null)
            {
                return null;
            }

            return listaCategorias;
        }
    }
}
