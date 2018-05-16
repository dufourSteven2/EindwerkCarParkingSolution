using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindwerkCarParkingLib
{
    public class Totalen
    {
        public int TotaalParkingKey { get; set; }
      [Required]
        public int Totaal { get; set; }
        public int Bezet { get; set; }

        //foreign key
        public int ParkingId { get; set; }

        //navigation property
        public virtual Parking Parking { get; set; }
        public virtual ICollection<Soort> Soort { get; set; }

 
    }
}
