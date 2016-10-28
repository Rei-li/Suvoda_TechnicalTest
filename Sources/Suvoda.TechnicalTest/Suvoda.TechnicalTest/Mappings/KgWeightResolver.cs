using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.Helpers;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Mappings
{
    public class KgWeightResolver : IValueResolver<DepotStockDto, DepotStockViewModel, decimal>
    {
        public decimal Resolve(DepotStockDto source, DepotStockViewModel destination, decimal member, ResolutionContext context)
        {
            return WeightConverter.ConvertPoundsToKg(source.DrugUnitsWeight);
        }
    }
}