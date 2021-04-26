using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly FizzBuzzWeb.Data.NumberContext _context;

        [BindProperty]
        public Number Number { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FizzBuzzWeb.Data.NumberContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Number.Data = DateTime.Now;
            bool divisible3 = false;
            bool divisible5 = false;
            if(Number.Liczba % 3 == 0)
            {
                divisible3 = true;

            }
            if(Number.Liczba % 5 == 0)
            {
                divisible5 = true;
            }
            if(divisible3 && divisible5)
            {
                Number.Wynik = "FizzBuzz";
            }
            else if (divisible3)
            {
                Number.Wynik = "Fizz";
            }
            else if (divisible5)
            {
                Number.Wynik = "Buzz";
            }
            else
            {
                Number.Wynik = $"Liczba {Number.Liczba} nie spełnia kryteriów";
            }
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("SessionNumber",
                JsonConvert.SerializeObject(Number));
                
            }
            _context.Number.Add(Number);
            _context.SaveChanges();

            return RedirectToPage("./Ostatnio_SZukane");
        }


    }
}
