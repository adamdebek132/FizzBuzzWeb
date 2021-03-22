using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Pages.Models;

namespace FizzBuzzWeb.Pages
{
    public class Ostatnio_SzukaneModel : PageModel
    {
        public Number Number { set; get; }
        public void OnGet()
        {
            var SessionNumber = HttpContext.Session.GetString("SessionNumber");
            if (SessionNumber != null)
                Number = JsonConvert.DeserializeObject<Number>(SessionNumber);
        }

    }
}
