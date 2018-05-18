using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EindwerkCarParkingLib
{
   public class Eigenaar
    {
        public int Id { get; set; }
        [Required]

        public string EigenaarNaam { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
