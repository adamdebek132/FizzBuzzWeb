using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages.Numbers
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.NumberContext _context;

        public DeleteModel(FizzBuzzWeb.Data.NumberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Number Number { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Number = await _context.Number.FirstOrDefaultAsync(m => m.ID == id);

            if (Number == null)
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

            Number = await _context.Number.FindAsync(id);

            if (Number != null)
            {
                _context.Number.Remove(Number);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
