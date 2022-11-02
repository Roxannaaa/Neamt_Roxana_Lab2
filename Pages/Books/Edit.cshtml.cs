using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Neamt_Roxana_Lab2.Data;
using Neamt_Roxana_Lab2.Models;

namespace Neamt_Roxana_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Neamt_Roxana_Lab2.Data.Neamt_Roxana_Lab2Context _context;
        public EditModel(Neamt_Roxana_Lab2.Data.Neamt_Roxana_Lab2Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 

            PopulateAssignedCategoryData(_context, Book);
            var authorList = _context.Author.Select(x => new
            {
                x.Id,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorId"] = new SelectList(authorList, "Id", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
           "PublisherName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookToUpdate = await _context.Book
            .Include(i => i.Publisher)
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Book>(
            bookToUpdate,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 

            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }

}
