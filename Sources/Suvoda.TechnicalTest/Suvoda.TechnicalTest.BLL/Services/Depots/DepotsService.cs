﻿using System.Collections.Generic;
using System.Linq;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Mappings;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.Depots;

namespace Suvoda.TechnicalTest.BLL.Services.Depots
{
    public class DepotsService : IDepotsService
    {
        private IDepotsRepository _depots;
        private IEntityDtoMapper _mapper;

        public DepotsService(IDepotsRepository depotsRepository, IEntityDtoMapper entityDtoMapper)
        {
            _depots = depotsRepository;
            _mapper = entityDtoMapper;
        }

        /// <summary>
        /// Get depots with drug units from that depot
        /// </summary>
        /// <returns>list of depots to display</returns>
        public IEnumerable<DepotViewDto> GetDepotsViewList()
        {
            List<DepotViewDto> models = new List<DepotViewDto>();
            var depots = _depots.GetDepots();
            foreach (var depot in depots)
            {
                if (depot.DrugUnits.Any())
                {
                    models.AddRange(depot.DrugUnits.Select(drugUnit => new DepotViewDto()
                    {
                        DepotId = depot.DepotId,
                        DepotName = depot.DepotName,
                        DepotLocation = depot.Country.CountryName,
                        DrugUnitId = drugUnit.DrugUnitId,
                        PickNumber = drugUnit.PickNumber,
                        DrugTypeName = drugUnit.DrugType.DrugTypeName
                    }));
                }
                else
                {
                    var depotModel = new DepotViewDto()
                    {
                        DepotId = depot.DepotId,
                        DepotName = depot.DepotName,
                        DepotLocation = depot.Country.CountryName
                    };

                    models.Add(depotModel);
                }

            }


            return models;
        }
        
        /// <summary>
        /// Get all depots
        /// </summary>
        /// <returns>list of depots </returns>
        public IEnumerable<LookupDto> GetDepotLookup()
        {
            var depots = _depots.GetDepots().ToList();
            var lookup = _mapper.AutoMapper.Map<List<Depot>, List<LookupDto>>(depots);
            return lookup;
        }


        /// <summary>
        /// Get total weight of drug units for every depot and drug type in kg
        /// </summary>
        /// <returns>list of view models with total weight of drug units in kg</returns>
        public IEnumerable<IEnumerable<DepotStockDto>> GetDepotsAssortment()
        {
            var depots = _depots.GetDepots();

            return (from depot in depots
                    where depot.DrugUnits.Any()
                    select (from unit in depot.DrugUnits
                            group unit by unit.DrugType
                        into typeGroup
                            select new DepotStockDto
                            {
                                DepotId = depot.DepotId,
                                DepotName = depot.DepotName,
                                DrugTypeId = typeGroup.Key.DrugTypeId,
                                DrugTypeName = typeGroup.Key.DrugTypeName,
                                DrugUnitsWeight = typeGroup.Sum(x => x.DrugType.Weight),
                            })).ToList();

        }
    }
}