using AutoMapper;
using EindwerkCarParking.Models;
using EindwerkCarParkingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EindwerkCarParking.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Parking, ParkingsDTO>()
                .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam));
                cfg.CreateMap<Parking, ParkingsDetailDTO>()
                .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam))
                .ForMember(dto => dto.LocatieStraat, conf => conf.MapFrom(lo => lo.Locatie.Straat));
                cfg.CreateMap<Locatie, LocatieDTO>();
                cfg.CreateMap<Gemeente, GemeenteDTO>();
                cfg.CreateMap<Land, LandDTO>();
                cfg.CreateMap<Soort, SoortDTO>();
                cfg.CreateMap<Eigenaar, EigenaarDTO>();

            });
        }
    }
}