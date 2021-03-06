﻿using System.Collections.Generic;
using System.Linq;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.BLL.Mappings;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.DrugUnits;

namespace Suvoda.TechnicalTest.BLL.Services.DrugUnits
{
    public class DrugUnitsService : IDrugUnitsService
    {
        private IDrugUnitsRepository _drugUnits;
        private IEntityDtoMapper _mapper;

        public DrugUnitsService(IDrugUnitsRepository drugUnitsRepository, IEntityDtoMapper entityDtoMapper)
        {
            _drugUnits = drugUnitsRepository;
            _mapper = entityDtoMapper;
        }

        /// <summary>
        /// Get all drug units
        /// </summary>
        /// <returns>List of drug units</returns>
        public IEnumerable<DrugUnitDto> GetDrugUnits()
        {
            var drugUnits = _drugUnits.GetDrugUnits();
            var drugUnitDtos = _mapper.AutoMapper.Map<IEnumerable<DrugUnit>, List<DrugUnitDto>>(drugUnits);
            return drugUnitDtos;
        }

        /// <summary>
        /// Get first suitable drug unit of certain type from certain depot with certain pickNumber
        /// </summary>
        /// <param name="pickNumber">number of units needed</param>
        /// <param name="drugTypeId">id of drug type</param>
        /// <param name="depotId">id of depot</param>
        /// <returns>first suitable drug unit according to  type, depot and pickNumber </returns>
        public DrugUnitDto GetDepotAvailableUnit(int pickNumber, int drugTypeId, int depotId)
        {
            var drugUnit = _drugUnits.GetDrugUnits().FirstOrDefault(x => x.PickNumber == pickNumber && x.DrugType.DrugTypeId == drugTypeId && x.DepotId == depotId);
            var drugUnitDto = _mapper.AutoMapper.Map<DrugUnit, DrugUnitDto>(drugUnit);
            return drugUnitDto;
        }

        /// <summary>
        /// Get drug unit by Id
        /// </summary>
        /// <param name="id">identificator of drug unit </param>
        /// <returns>drug unit with certain Id</returns>
        public DrugUnitDto GetDrugUnitById(int? id)
        {
            var drugUnit =_drugUnits.GetDrugUnitById(id);
            var drugUnitDto = _mapper.AutoMapper.Map<DrugUnit, DrugUnitDto>(drugUnit);
            return drugUnitDto;
        }

        /// <summary>
        /// Save drug unit
        /// </summary>
        /// <param name="dto">drug unit to save</param>
        public void Save(DrugUnitDto dto)
        {
            var drugUnit = _mapper.AutoMapper.Map<DrugUnitDto, DrugUnit>(dto);
            _drugUnits.Save(drugUnit);
        }


    }
}