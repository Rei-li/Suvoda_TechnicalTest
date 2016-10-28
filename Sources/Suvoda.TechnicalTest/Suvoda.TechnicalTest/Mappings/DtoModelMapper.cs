using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.Helpers;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Mappings
{
    public class DtoModelMapper: IDtoModelMapper
    {
       public IMapper AutoMapper { get; set; }

        public DtoModelMapper()
       {
           AutoMapper = RegisterMappings();
       }

        private IMapper RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepotViewDto, DepotViewModel>();
                cfg.CreateMap<DepotViewModel, DepotViewDto>();

                cfg.CreateMap<DrugTypeDto, DrugTypeViewModel>().MaxDepth(3);
                cfg.CreateMap<DrugTypeViewModel, DrugTypeDto>().MaxDepth(3);

                cfg.CreateMap<DepotStockDto, DepotStockViewModel>()
         .ForMember(dest => dest.DrugUnitsWeight, opt => opt.ResolveUsing<KgWeightResolver>());
               
                cfg.CreateMap<DrugUnitDto, DrugUnitsViewModel>().MaxDepth(3);
                cfg.CreateMap<DrugUnitsViewModel, DrugUnitDto>().MaxDepth(3);


            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();

        }
        
    }
    
}