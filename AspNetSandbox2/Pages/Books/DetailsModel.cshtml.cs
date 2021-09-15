using System.Threading.Tasks;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox2.Pages.Shared
{
    /// <summary>Shows details about a book.</summary>
    public class DetailsModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;

        public DetailsModel(AspNetSandbox2.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
