using AutoMapper;
using EindwerkCarParkingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //http://www.projectcodify.com/using-automapper-in-aspnet-core bron code
        {
            CreateMap<Parking, ParkingsDTO>()
                .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam));
            CreateMap<Parking, ParkingsDetailDTO>()
            .ForMember(dto => dto.GemeenteGemeenteNaam, conf => conf.MapFrom(gem => gem.Locatie.Gemeente.GemeenteNaam))
            .ForMember(dto => dto.LocatieStraat, conf => conf.MapFrom(lo => lo.Locatie.Straat));
            CreateMap<Locatie, LocatieDTO>();
            CreateMap<Gemeente, GemeenteDTO>();
            CreateMap<Land, LandDTO>();
            CreateMap<Soort, SoortDTO>();
            CreateMap<Eigenaar, EigenaarDTO>();
        }
    }
}
