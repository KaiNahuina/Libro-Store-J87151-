using Libro_Store.Data;

namespace Libro_Store.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Libros.Any())
            {
                return;
            }
            var libros = new Libros[]
            {
                new Libros{Title ="First Book", Author="First Author",Price=1m, Description="First Description"}
            };
            context.Libros.AddRange(libros);
            context.SaveChanges();

        }
    }
}
