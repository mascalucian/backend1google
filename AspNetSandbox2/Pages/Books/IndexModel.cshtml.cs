using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox2.Pages.Shared
{
    /// <summary>Model for main dashboard of books.</summary>
    public class IndexModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;

        public IndexModel(AspNetSandbox2.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
