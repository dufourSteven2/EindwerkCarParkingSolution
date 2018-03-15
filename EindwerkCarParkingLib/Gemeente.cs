using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindwerkCarParkingLib
{
    public class Gemeente
    {
        public int Id { get; set; }
        [Required]

        public string GemeenteNaam { get; set; }

        public virtual ICollection<Locatie> Locaties { get; set; }
    }
}
