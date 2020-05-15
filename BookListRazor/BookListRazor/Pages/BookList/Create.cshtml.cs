using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel( ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
         public Book Book { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); //add in queue
                await _db.SaveChangesAsync();// push data into the database
                return RedirectToPage("Index");// redirect to main page
            }
            else
            {
                return Page();
            }
        }

    }
}