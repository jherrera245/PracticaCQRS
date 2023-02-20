using APICQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace APICQRS.Data
{
    public class AppDbContext : DbContext
    {
        //constructor para la conexion a la base de datos
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //tablas de la base de datos
        public DbSet<Categorias> Categorias { get; set; }
    }
}
