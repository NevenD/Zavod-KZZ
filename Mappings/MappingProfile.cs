using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Dtos;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
            CreateMap<RoadCategory, RoadCategoryDTO>();
            CreateMap<Road, RoadDTO>();
            CreateMap<RoadGeometry, RoadGeometryDTO>();
        }
    }
}
