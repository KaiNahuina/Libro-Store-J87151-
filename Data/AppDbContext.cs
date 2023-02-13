using Microsoft.EntityFrameworkCore;

namespace Libro_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Libros is nameof of db
        public DbSet<Libros> Libros { get; set; }
    }
}
