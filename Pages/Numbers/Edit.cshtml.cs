using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages.Numbers
{
    public class EditModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.NumberContext _context;

        public EditModel(FizzBuzzWeb.Data.NumberContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Number).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberExists(Number.ID))
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

        private bool NumberExists(int id)
        {
            return _context.Number.Any(e => e.ID == id);
        }
    }
}
