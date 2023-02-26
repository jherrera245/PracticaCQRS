using APICQRS.Data;
using APICQRS.Models;
using MediatR;
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
            var listaCategorias = await _context.Categorias.ToListAsync();

            if (listaCategorias == null)
            {
                return null;
            }
            return listaCategorias.AsReadOnly();
        }
    }
}
