using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.DataLayer;
using Library.Entity;

namespace Library.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Library.DataLayer.BookDBContext _context;

        public DeleteModel(Library.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ThesisEntity ThesisEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ThesisCollections == null)
            {
                return NotFound();
            }

            var thesisentity = await _context.ThesisCollections.FirstOrDefaultAsync(m => m.Id == id);

            if (thesisentity == null)
            {
                return NotFound();
            }
            else 
            {
                ThesisEntity = thesisentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ThesisCollections == null)
            {
                return NotFound();
            }
            var thesisentity = await _context.ThesisCollections.FindAsync(id);

            if (thesisentity != null)
            {
                ThesisEntity = thesisentity;
                _context.ThesisCollections.Remove(ThesisEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
