using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
   public class Soort
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
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
