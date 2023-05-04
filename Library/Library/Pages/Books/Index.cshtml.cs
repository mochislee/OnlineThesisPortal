using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.DataLayer;
using Library.Entity;
using Microsoft.Data.SqlClient;
using System.Dynamic;
using System.Configuration;
using NuGet.Protocol.Core.Types;



namespace Library.Pages.Books
{
        public class IndexModel : PageModel
        {

            private readonly Library.DataLayer.BookDBContext _context;

            public string CurrentFilter { get; set; }

            public IndexModel(Library.DataLayer.BookDBContext context)
            {
                _context = context;
            }

            public IList<ThesisEntity> ThesisEntity { get; set; } = default!;
            

            public async Task OnGetAsync(string searchString)
            {


                if (_context.ThesisCollections != null)
                {
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        ThesisEntity = await _context.ThesisCollections.Where(s => s.thesisTitle.Contains(searchString) ||
                        s.thesisDescription.Contains(searchString) ||
                        s.thesisAuthor.Contains(searchString) ||
                        s.thesisCourse.Contains(searchString)).ToListAsync();

                    }
                    else
                    {
                        ThesisEntity = await _context.ThesisCollections.ToListAsync();
                    }

                }
            }
        }
    }


   



