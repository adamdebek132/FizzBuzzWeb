using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace FizzBuzzWeb.Pages.Models
{
    public class Number
    {
        [Range(1, 1000, ErrorMessage = "Liczba spoza zakresu")]
        [Display(Name = "Podaj liczbę całkowitą od 1 do 1000")]
        public int Liczba { get; set; }

    }
}
