using System;
using System.ComponentModel.DataAnnotations;

namespace Museum.ViewModels
{
    public class ExhibitsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}
