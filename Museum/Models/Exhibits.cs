using System;
using System.ComponentModel.DataAnnotations;

namespace Museum.Models
{
    public class Exhibits
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
