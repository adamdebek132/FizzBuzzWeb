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
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.NumberContext _context;

        public IndexModel(FizzBuzzWeb.Data.NumberContext context)
        {
            _context = context;
        }

        public IList<Number> Number { get;set; }

        public async Task OnGetAsync()
        {
            Number = await _context.Number.ToListAsync();
        }
    }
}
