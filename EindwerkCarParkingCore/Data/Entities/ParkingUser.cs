using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Data.Entities
{
    public class ParkingUser : IdentityUser
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }


    }
}
