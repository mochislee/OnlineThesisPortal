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
    public class DetailsModel : PageModel
    {
        private readonly Library.DataLayer.BookDBContext _context;

        public DetailsModel(Library.DataLayer.BookDBContext context)
        {
            _context = context;
        }
     
        public ThesisEntity ThesisEntity { get; set; } = default!;
        protected void Page_Load(object sender, EventArgs e)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            PdfFileDatabase pdfFileDb = new PdfFileDatabase(connectionString);

            try
            {

                ThesisEntity pdfFile = new ThesisEntity();

                pdfFile.Id = 1;
                pdfFile.FilePath = "C:/Users/kriselle/source/repos/Library/Library/wwwroot/pdf/id-1-DonJuan.pdf";

                pdfFile.BinaryContent = System.IO.File.ReadAllBytes(pdfFile.FilePath);

                pdfFileDb.InsertPdfFile(pdfFile);

                Console.WriteLine("Binary content length: " + pdfFile.BinaryContent.Length);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error inserting PDF file: " + ex.Message);
            }

        }
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
    }
}
