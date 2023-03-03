using APICQRS.Data;
using APICQRS.Models;
using MediatR;

namespace APICQRS.Commands
{
    public class UpdateCategoriaHandler : IRequestHandler<UpdateCategoria, Categorias>
    {
        //objeto AppDbContext para conexion a base de datos
        private readonly AppDbContext _context;
        // constructor
        public UpdateCategoriaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categorias> Handle(
            UpdateCategoria request, CancellationToken cancellationToken
        )
        {
            //Verficamos que la categoria existe.
            var categoria = _context.Categorias.FirstOrDefault(
                x => x.IdCategoria == request.IdCategoria
            );

            //si no existe retornamos null
            if ( categoria is null )
            {
                return null;
            }

            //si existe actualizamos el registro
            categoria.NombreCategoria = request.NombreCategoria;
            categoria.DescripcionCategoria = request.DescripcionCategoria;
            await _context.SaveChangesAsync(); //guardamos los cambios
            
            return categoria;
        }
    }
}
