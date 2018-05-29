using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
  public  class Land
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]

        public string LandNaam { get; set; }

        public virtual ICollection<Gemeente> Gemeente { get; set; }
    }
}
