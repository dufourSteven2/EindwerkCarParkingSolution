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
        
        // Foreign Key
        public int TotaalId { get; set; }
        
        // Navigation property
        public virtual Totaal Totaal { get; set; }

        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
