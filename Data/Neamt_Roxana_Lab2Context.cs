using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Neamt_Roxana_Lab2.Models;

namespace Neamt_Roxana_Lab2.Data
{
    public class Neamt_Roxana_Lab2Context : DbContext
    {
        public Neamt_Roxana_Lab2Context (DbContextOptions<Neamt_Roxana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Neamt_Roxana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Neamt_Roxana_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Neamt_Roxana_Lab2.Models.Author> Author { get; set; }

        public DbSet<Neamt_Roxana_Lab2.Models.Category> Category { get; set; }

        public DbSet<Neamt_Roxana_Lab2.Models.Category> BookCategory { get; set; }
    }
}
