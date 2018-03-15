using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindwerkCarParkingLib
{
    public class Soort
    {
        public int Id { get; set; }
        [Required]

        public string SoortNaam { get; set; }

        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
