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
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Libros Book { get; set; }

        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(String Title)
        {//Libros here is table name
            Book = _db.Libros.Find(Title);
        }

        //Code adapted from Richard Stocker, 2022
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
