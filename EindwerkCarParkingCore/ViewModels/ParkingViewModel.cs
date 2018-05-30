using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.ViewModels
{
    public class ParkingViewModel
    {
        [Required]
        [Display(Name="Landen")]
        public string SelectedLand { get; set; }
        public IEnumerable<SelectListItem> Landen { get; set; }

        [Required]
        [Display(Name = "Steden")]
        public string SelectedStad { get; set; }
        public IEnumerable<SelectListItem> Steden { get; set; }
    }
}
