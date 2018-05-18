using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
 public  class Locatie
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]

        public string Straat { get; set; }
        public string Nr { get; set; }

        //Foreign Key

        public int GemeenteId { get; set; }


        //Navigation Property

        public virtual Gemeente Gemeente { get; set; }


        public virtual ICollection<Parking> Parkings { get; set; }
    }
}
