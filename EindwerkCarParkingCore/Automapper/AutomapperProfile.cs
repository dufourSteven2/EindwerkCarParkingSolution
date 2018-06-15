using AutoMapper;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Parking, ParkingsDTO>()
                .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam));
            CreateMap<Parking, ParkingsDetailDTO>()
            .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam))
            .ForMember(dto => dto.LocatieStraat, conf => conf.MapFrom(lo => lo.Locatie.Straat))
            .ForMember(dto => dto.LocatieNummer, conf => conf.MapFrom(locNr => locNr.Locatie.Nr))
            .ForMember(dto => dto.LandLandNaam, conf => conf.MapFrom(lan => lan.Locatie.Gemeente.Land.LandNaam))
            .ForMember(dto => dto.SoortSoortNaam, conf => conf.MapFrom(so => so.Soort.SoortNaam))
            .ForMember(dto => dto.ParkingUsersEigenaarNaam, conf => conf.MapFrom(beNa => beNa.Eigenaar.EigenaarNaam));
            CreateMap<Locatie, LocatieDTO>();
            CreateMap<Gemeente, GemeenteDTO>();
            CreateMap<Land, LandDTO>();
           // CreateMap<Soort, SoortDTO>();
            CreateMap<ParkingUsers, ParkingUsersDTO>();
            //CreateMap<Totaal, TotaalDTO>();

        }
    }
}
