using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Muzeu.Models
{
    public class Incidents
    {
        
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }


        public string Description { set; get; }

        [Required]
        public string Priority { set; get; }

        [Required]
        public DateTime Date { set; get; }

        [Required]
        public Boolean Solved { set; get; }
    }
}
