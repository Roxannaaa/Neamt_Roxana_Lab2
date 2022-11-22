using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Neamt_Roxana_Lab2.Data;
using Neamt_Roxana_Lab2.Models;

namespace Neamt_Roxana_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]

    public class DetailsModel : PageModel
    {
        private readonly Neamt_Roxana_Lab2.Data.Neamt_Roxana_Lab2Context _context;

        public DetailsModel(Neamt_Roxana_Lab2.Data.Neamt_Roxana_Lab2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
