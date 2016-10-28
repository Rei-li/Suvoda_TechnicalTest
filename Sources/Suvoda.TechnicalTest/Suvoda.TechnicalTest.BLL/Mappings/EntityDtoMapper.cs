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
    public class EntityDtoMapper
    {
        public static IMapper RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Depot, LookupDto>()
                .ForMember(ev => ev.Key, m => m.MapFrom(a => a.DepotId))
                .ForMember(ev => ev.Value, m => m.MapFrom(a => a.DepotName));

                cfg.CreateMap<Depot, DepotDto>().MaxDepth(3);
               // .ForMember(ev => ev.DrugUnits, m => m.Ignore());
                cfg.CreateMap<DepotDto, Depot>().MaxDepth(3);
               // .ForMember(ev => ev.DrugUnits, m => m.Ignore());

                cfg.CreateMap<DrugType, DrugTypeDto>();
                cfg.CreateMap<DrugTypeDto, DrugType>();

                cfg.CreateMap<DrugUnit, DrugUnitDto>().MaxDepth(3);
                cfg.CreateMap<DrugUnitDto, DrugUnit>().MaxDepth(3);

                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<CountryDto, Country>();

                cfg.CreateMap<DepotDestination, DepotDestinationDto>();
                cfg.CreateMap<DepotDestinationDto, DepotDestination>();


            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
