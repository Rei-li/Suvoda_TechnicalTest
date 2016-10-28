using System.Collections.Generic;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.DrugTypes;

namespace Suvoda.TechnicalTest.BLL.Services.DrugTypes
{
    public class DrugTypesService : ServiceBase, IDrugTypesService
    {
        private IDrugTypesRepository _drugTypes;

        public DrugTypesService(IDrugTypesRepository drugTypesRepository)
        {
            _drugTypes = drugTypesRepository;
        }

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