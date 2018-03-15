using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindwerkCarParkingLib
{
    public class Locatie
    {
        public int Id { get; set; }
        [Required]

        public string Straat { get; set; }

        //Foreign Key
        public int LandId { get; set; }
        public int GemeenteId { get; set; }


        //Navigation Property
        public virtual Land Land { get; set; }
        public virtual Gemeente Gemeente { get; set; }


        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
