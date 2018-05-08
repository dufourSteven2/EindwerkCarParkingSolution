using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EindwerkCarParking.Models
{
    public class ParkingsDTO
    {
        public int Id { get; set; }
        public string ParkingNaam { get; set; }
        public string GemeenteGemeenteNaam { get; set; }

    }

    public class ParkingsDetailDTO
    {
        public int Id { get; set; }
        public string ParkingNaam { get; set; }
        public string LocatieStraat { get; set; }
        public string GemeenteGemeenteNaam { get; set; }
        public string LandLandNaam { get; set; }
    }

    public class EigenaarDTO
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

    public class TotalenDTO
    {
        public int Totaal { get; set; }
        public int Bezet { get; set; }
    }
}