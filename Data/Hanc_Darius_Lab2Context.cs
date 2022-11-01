using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hanc_Darius_Lab2.Models;

namespace Hanc_Darius_Lab2.Data
{
    public class Hanc_Darius_Lab2Context : DbContext
    {
        public Hanc_Darius_Lab2Context (DbContextOptions<Hanc_Darius_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Hanc_Darius_Lab2.Models.Bookcs> Bookcs { get; set; } = default!;

        public DbSet<Hanc_Darius_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Hanc_Darius_Lab2.Models.Author> Author { get; set; }

        public DbSet<Hanc_Darius_Lab2.Models.Category> Category { get; set; }
    }
}
