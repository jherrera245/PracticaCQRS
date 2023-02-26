using APICQRS.Data;
using APICQRS.Models;
using MediatR;

namespace APICQRS.Commands
{
    public class CreateCategoriaHandler : IRequestHandler<CreateCategoria, Categorias>
    {
        //objeto AppDbContext para conexion a base de datos
        private readonly AppDbContext _context;
        // constructor
        public CreateCategoriaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categorias> Handle(
            CreateCategoria request, CancellationToken cancellationToken
        )
        {
            //creando objeto de tipo categoria
            var categoria = new Categorias() { 
                NombreCategoria = request.NombreCategoria,
                DescripcionCategoria = request.DescripcionCategoria
            };

            //guardamos los datos en la base de datos
            _context.Categorias.Add( categoria );
            await _context.SaveChangesAsync();
            return categoria; //retornamos en dato ingresado
        }
    }
}
