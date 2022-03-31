#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using practice_Razor.Models;

namespace practice_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly practice_Razor.Models.ApiDbContext _context;

        public IndexModel(practice_Razor.Models.ApiDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
