using System.Threading.Tasks;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox2.Pages.Shared
{
    /// <summary>Deletes books.</summary>
    public class DeleteModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;

        public DeleteModel(AspNetSandbox2.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FindAsync(id);

            if (Book != null)
            {
                this.context.Book.Remove(Book);
                await this.context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
