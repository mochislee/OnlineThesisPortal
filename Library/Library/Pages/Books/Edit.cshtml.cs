using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.DataLayer;
using Library.Entity;

namespace Library.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Library.DataLayer.BookDBContext _context;

        public EditModel(Library.DataLayer.BookDBContext context)
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

            var thesisentity =  await _context.ThesisCollections.FirstOrDefaultAsync(m => m.Id == id);
            if (thesisentity == null)
            {
                return NotFound();
            }
            ThesisEntity = thesisentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ThesisEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThesisEntityExists(ThesisEntity.Id))
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

        private bool ThesisEntityExists(int id)
        {
          return (_context.ThesisCollections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
