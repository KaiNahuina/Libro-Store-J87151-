using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Libro_Store.Data;

namespace Libro_Store.Pages.Shop
{
    public class ShopModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<Libros> Books { get; set; }

        public ShopModel(AppDbContext db)
        {
            _db = db;

        }
        public void OnGet()
        {
            Books = _db.Libros;
        }
    }
}
