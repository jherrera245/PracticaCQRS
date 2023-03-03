using APICQRS.Data;
using APICQRS.Models;
using MediatR;

namespace APICQRS.Commands
{
    public class DeleteCategoriaHandler : IRequestHandler<DeleteCategoria, Categorias>
    {
        //objeto AppDbContext para conexion a base de datos
        private readonly AppDbContext _context;
        // constructor
        public DeleteCategoriaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categorias> Handle(
            DeleteCategoria request, CancellationToken cancellationToken
        )
        {
            //Verficamos que la categoria existe.
            var categoria = _context.Categorias.FirstOrDefault(
                x => x.IdCategoria == request.IdCategoria
            );

            //si no existe retornamos null
            if (categoria is null)
            {
                return null;
            }

            //si existe removemos la categoria
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
