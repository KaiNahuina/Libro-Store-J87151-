using Microsoft.EntityFrameworkCore;

namespace Libro_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Libros> Libros { get; set; }
    }
}
