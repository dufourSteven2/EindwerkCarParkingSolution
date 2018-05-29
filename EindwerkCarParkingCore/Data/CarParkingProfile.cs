using AutoMapper;
using AutoMapper.QueryableExtensions;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingLib;
using EindwerkCarParkingCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Data
{
    public class CarParkingProfile : Profile
    {
        public CarParkingProfile()
        {
            //CreateMap<Locatie, LocatieViewModel>()
            //    .ForMember(l => l.LocatieId, ex => ex.MapFrom(l => l.Id))
            //    .ReverseMap();
            CreateMap<Parking, ParkingsDTO>()
                .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam))
                .ReverseMap();
            CreateMap<Parking, ParkingsDetailDTO>()
            .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam))
            .ForMember(dto => dto.LocatieStraat, conf => conf.MapFrom(lo => lo.Locatie.Straat))
            .ReverseMap();
            CreateMap<Locatie, LocatieDTO>().ReverseMap();
            CreateMap<Gemeente, GemeenteDTO>().ReverseMap();
            CreateMap<Land, LandDTO>().ReverseMap();
            CreateMap<Soort, SoortDTO>().ReverseMap();
            CreateMap<Eigenaar, EigenaarDTO>().ReverseMap();
            CreateMap<Totaal, ToataalDTO>().ReverseMap();
        }
    }
}
