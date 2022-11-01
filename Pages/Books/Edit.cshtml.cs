using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hanc_Darius_Lab2.Data;
using Hanc_Darius_Lab2.Models;

namespace Hanc_Darius_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context _context;

        public EditModel(Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Bookcs Bookcs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookcs == null)
            {
                return NotFound();
            }

            Bookcs = await _context.Bookcs
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            PopulateAssignedCategoryData(_context, Bookcs);

            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });


            var bookcs =  await _context.Bookcs.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcs == null)
            {
                return NotFound();
            }

            Bookcs = bookcs;
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var bookToUpdate = await _context.Bookcs
                    .Include(i => i.Publisher)
                    .Include(i => i.BookCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Bookcs>(bookToUpdate, "Book", i => i.Title, i => i.Author, i => i.Price, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();



            _context.Attach(Bookcs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookcsExists(Bookcs.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookcsExists(int id)
        {
          return _context.Bookcs.Any(e => e.ID == id);
        }
    }
}
