using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.ViewModels
{
    public class LocatieViewModel
    {
        public int LocatieId { get; set; }
        [Required]
        public string Straat { get; set; }
        [Required]
        public string Nr { get; set; }
    }
}
