using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.DataLayer;
using Library.Entity;

namespace Library.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Library.DataLayer.BookDBContext _context;

        public CreateModel(Library.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ThesisEntity ThesisEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ThesisCollections == null || ThesisEntity == null)
            {
                return Page();
            }

            _context.ThesisCollections.Add(ThesisEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
