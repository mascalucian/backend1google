using System.Threading.Tasks;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetSandbox2.Pages.Shared
{
    /// <summary>Creates new books to add to our data.</summary>
    public class CreateModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;

        public CreateModel(AspNetSandbox2.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Book.Add(Book);
            await this.context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
