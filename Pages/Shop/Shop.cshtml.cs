using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Libro_Store.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Libro_Store.Pages.Shop
{
    public class ShopModel : PageModel
    {
        private readonly AppDbContext _db;

        //Books is an instance of type Libros
        public IEnumerable<Libros> Books { get; set; }

        public ShopModel(AppDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public string Search { get; set; }
        public IList<Libros> Libros { get; set; } = default!;

        public void OnGet()
        {
            Books = _db.Libros.FromSqlRaw("Select * FROM Libros").ToList();
        }

        public IActionResult OnPostSearch()
        {
            Books = _db.Libros.FromSqlRaw("SELECT * FROM Libros WHERE Title LIKE '" + Search+ "%'").ToList();
            return Page();
        }

    }
}
