using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindwerkCarParkingLib
{
    public class Parking
    {
        public int Id { get; set; }
        [Required]

        public string ParkingNaam { get; set; }
        public int Totaal { get; set; }
        public int Bezet { get; set; }

        //Foreign Key
        public int EigenaarId { get; set; }
        public int SoortId { get; set; }
        public int LocatieId { get; set; }

        //Navigation Property
        public virtual Eigenaar Eigenaar { get; set; }
        public virtual Soort Soort { get; set; }
        public virtual Locatie Locatie { get; set; }
    }
}
