using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Range(10, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Function { get; set; }

    }
}
