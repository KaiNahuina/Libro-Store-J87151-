using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Libro_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Libro_Store.Pages.Create
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Libros Book { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            //Books.Active = true;
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Book.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            await _db.Libros.AddAsync(Book);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Shop/Shop");
        }
    }
}
