using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hanc_Darius_Lab2.Data;
using Hanc_Darius_Lab2.Models;

namespace Hanc_Darius_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context _context;

        public IndexModel(Hanc_Darius_Lab2.Data.Hanc_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Bookcs> Bookcs { get;set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();
            BookD.Books = await _context.Bookcs
             .Include(b => b.Publisher)
             .Include(b => b.BookCategories)
             .ThenInclude(b => b.Category)
             .AsNoTracking()
             .OrderBy(b => b.Title)
             .ToListAsync();

            if (_context.Bookcs != null)
            {
                Bookcs = await _context.Bookcs
                    .Include(b => b.Publisher)
                    .Include(c => c.Author)
                    .ToListAsync();
            }
            if (id != null)
            {
                BookID = id.Value;
                Bookcs book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
