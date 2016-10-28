using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.BLL.Mappings;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.DrugUnits;

namespace Suvoda.TechnicalTest.BLL.Services
{
    public class DrugUnitsService : ServiceBase
    {
        private DrugUnitsRepository _drugUnits = new DrugUnitsRepository();

        /// <summary>
        /// Get all drug units
        /// </summary>
        /// <returns>List of drug units</returns>
        public IEnumerable<DrugUnitDto> GetDrugUnits()
        {
            var drugUnits = _drugUnits.GetDrugUnits();
            var drugUnitDtos = Mapper.Map<IEnumerable<DrugUnit>, List<DrugUnitDto>>(drugUnits);
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
            var drugUnitDto = Mapper.Map<DrugUnit, DrugUnitDto>(drugUnit);
            return drugUnitDto;
        }

        public DrugUnitDto GetDrugUnitById(int? id)
        {
            var drugUnit =_drugUnits.GetDrugUnitById(id);
            var drugUnitDto = Mapper.Map<DrugUnit, DrugUnitDto>(drugUnit);
            return drugUnitDto;
        }

        public void Save(DrugUnitDto dto)
        {
            var drugUnit = Mapper.Map<DrugUnitDto, DrugUnit>(dto);
            _drugUnits.Save(drugUnit);
        }


    }
}