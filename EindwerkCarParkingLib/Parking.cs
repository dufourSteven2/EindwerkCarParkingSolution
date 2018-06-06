using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
  public  class Parking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]

        public string ParkingNaam { get; set; }
        public int Totaal { get; set; }
        public int Bezet { get; set; }
        public bool PublicatieToelating { get; set; }  //wanneer deze bool op true staat, kan de parking getoond worden op de website
        public decimal Percentage
        {

            get
            {
                decimal totaal;
                decimal bezet;
                totaal = Totaal;
                bezet = Bezet;
                return (bezet / totaal) * 100;
                
            }
        }
        //Foreign Key
        public string ParkingUsersName { get; set; }
        public int SoortId { get; set; }
        public int LocatieId { get; set; }

        //Navigation Property
        public virtual ParkingUsers Eigenaar { get; set; }
        public virtual Soort Soort { get; set; }
      public virtual Locatie Locatie { get; set; }

    }
}
