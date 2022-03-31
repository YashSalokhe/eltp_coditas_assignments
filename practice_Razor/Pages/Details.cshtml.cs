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
    public class DetailsModel : PageModel
    {
        private readonly practice_Razor.Models.ApiDbContext _context;

        public DetailsModel(practice_Razor.Models.ApiDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryRowId == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
