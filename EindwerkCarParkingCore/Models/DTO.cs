using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Models
{
   public class ParkingsDTO
    {
        public int Id { get; set; }
        public string ParkingNaam { get; set; }
        public string GemeenteGemeenteNaam { get; set; }
        public bool PublicatieToelating { get; set; }  //wanneer deze bool op true staat, kan de parking getoond worden op de website


    }

    public class ParkingsDetailDTO
    {
        public int Id { get; set; }
        public string ParkingNaam { get; set; }
        public string LocatieStraat { get; set; }
        public string LocatieNummer { get; set; }
        public string GemeenteGemeenteNaam { get; set; }
        public string LandLandNaam { get; set; }
        public string SoortSoortNaam { get; set; }
        public int Totaal { get; set; }
        public int Bezet { get; set; }
        public decimal Percentage { get; set; }
        public string ParkingUsersEigenaarNaam { get; set; }
        public bool PublicatieToelating { get; set; }  //wanneer deze bool op true staat, kan de parking getoond worden op de website

    }

    public class ParkingUsersDTO
    {
        public int Id { get; set; }
        public string EigenaarNaam { get; set; }
    }

    public class GemeenteDTO
    {
        public int Id { get; set; }
        public string GemeenteNaam { get; set; }
    }

    public class LocatieDTO
    {
        public int Id { get; set; }
        public string Straat { get; set; }
    }

    public class LandDTO
    {
        public int Id { get; set; }
        public string LandNaam { get; set; }
    }
    public class SoortDTO
    {
        public int Id { get; set; }
        public string SoortNaam { get; set; }
            }

    public class TotaalDTO
    {
        public int Id { get; set; }
        public int MaxParkings { get; set; }
        public int BezetteParkings { get; set; }
        public int SoortId { get; set; }
    }
}