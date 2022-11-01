using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hanc_Darius_Lab2.Data;
using Hanc_Darius_Lab2.Models;

namespace Hanc_Darius_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context _context;

        public CreateModel(Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID","PublisherName");
            return Page();
            
            var book = new Bookcs();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
        }

        [BindProperty]
        public Bookcs Bookcs { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       
            public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
            {
                var newBook = new Bookcs();
                if (selectedCategories != null)
                {
                    newBook.BookCategories = new List<BookCategory>();
                    foreach (var cat in selectedCategories)
                    {
                        var catToAdd = new BookCategory
                        {
                            CategoryID = int.Parse(cat)
                        };
                        newBook.BookCategories.Add(catToAdd);
                    }
                }
                if (await TryUpdateModelAsync<Bookcs>(
                newBook,
                "Book",
                i => i.Title, i => i.Author,
                i => i.Price, i => i.PublishingDate, i => i.PublisherID))
                {
                    _context.Bookcs.Add(newBook);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                PopulateAssignedCategoryData(_context, newBook);
                return Page();
            }
        }
    
}
