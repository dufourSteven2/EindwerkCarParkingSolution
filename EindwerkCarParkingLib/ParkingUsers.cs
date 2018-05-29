using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EindwerkCarParkingLib
{
   public class ParkingUsers : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]

        public string EigenaarNaam { get; set; }
       
       // public virtual ICollection<Parking> Parkings { get; set; }
    }
}
