using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
   public class Totaal
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]

        public int MaxParkings { get; set; }
        public int BezetteParkings { get; set; }

        //Navigation property

        public virtual ICollection<Soort> Soorts { get; set; }
    }
}
