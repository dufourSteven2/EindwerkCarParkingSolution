using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EindwerkCarParkingLib
{
    class Land
    {
        public int Id { get; set; }
        [Required]

        public string LandNaam { get; set; }

        public virtual ICollection<Locatie> Locaties { get; set; }
    }
}
