using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Country;
using Suvoda.TechnicalTest.BLL.Dto.DepotDestination;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.DAL;

namespace Suvoda.TechnicalTest.BLL.Mappings
{
    public class EntityDtoMapper : IEntityDtoMapper
    {
        public IMapper AutoMapper { get; set; }

        public EntityDtoMapper()
        {
            AutoMapper = RegisterMappings();
        }

        private IMapper RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Depot, LookupDto>()
                .ForMember(ev => ev.Key, m => m.MapFrom(a => a.DepotId))
                .ForMember(ev => ev.Value, m => m.MapFrom(a => a.DepotName));

                cfg.CreateMap<Depot, DepotDto>().MaxDepth(3).ReverseMap();

                cfg.CreateMap<DrugType, DrugTypeDto>().ReverseMap();

                cfg.CreateMap<DrugUnit, DrugUnitDto>().MaxDepth(3).ReverseMap();

                cfg.CreateMap<Country, CountryDto>().ReverseMap();

                cfg.CreateMap<DepotDestination, DepotDestinationDto>().ReverseMap();


            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
