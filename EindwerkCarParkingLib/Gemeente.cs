using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
   public class Gemeente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]

        public string GemeenteNaam { get; set; }
        public int LandId { get; set; }
        public virtual Land Land { get; set; }
        public virtual ICollection<Locatie> Locaties { get; set; }
    }
}
