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

        public async Task OnGetAsync()
        {
            if (_context.Bookcs != null)
            {
                Bookcs = await _context.Bookcs
                    .Include(b => b.Publisher)

                    .ToListAsync();
            }
        }
    }
}
