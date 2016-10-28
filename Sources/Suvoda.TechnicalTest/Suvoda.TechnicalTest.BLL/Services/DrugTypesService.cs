using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Mappings;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.DrugTypes;
using Suvoda.TechnicalTest.Dto;
using Suvoda.TechnicalTest.Dto.DrugTypes;

namespace Suvoda.TechnicalTest.BLL.Services
{
    public class DrugTypesService : ServiceBase
    {
        private DrugTypesRepository _drugTypes = new DrugTypesRepository();

        /// <summary>
        /// Get all drug types
        /// </summary>
        /// <returns>list of drug types </returns>
        public IEnumerable<DrugTypeDto> GetDrugTypes()
        {
            var drugTypes = _drugTypes.GetDrugTypes();
            var drugTypesList = Mapper.Map<IEnumerable<DrugType>, List<DrugTypeDto>>(drugTypes);
            return drugTypesList;
        }
    }
}