using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    public class Zapisane_w_sesjiModel : PageModel
    {
        private readonly NumberContext _context;
        public Zapisane_w_sesjiModel( NumberContext context)
        {
            _context = context;
        }
        public IList<Number> Numbers { get; set; }
        public void OnGet()
        {
            Numbers = _context.Number.ToList();
            Numbers = Numbers.TakeLast(10).ToList();
            Numbers.OrderByDescending(a => a.Data);
        }

    }
}
