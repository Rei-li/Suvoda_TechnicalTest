using System.Collections.Generic;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Mappings;
using Suvoda.TechnicalTest.DAL;
using Suvoda.TechnicalTest.DAL.Repositories.DrugTypes;

namespace Suvoda.TechnicalTest.BLL.Services.DrugTypes
{
    public class DrugTypesService : IDrugTypesService
    {
        private IDrugTypesRepository _drugTypes;
        private IEntityDtoMapper _mapper;

        public DrugTypesService(IDrugTypesRepository drugTypesRepository, IEntityDtoMapper entityDtoMapper)
        {
            _drugTypes = drugTypesRepository;
            _mapper = entityDtoMapper;
        }

        /// <summary>
        /// Get all drug types
        /// </summary>
        /// <returns>list of drug types </returns>
        public IEnumerable<DrugTypeDto> GetDrugTypes()
        {
            var drugTypes = _drugTypes.GetDrugTypes();
            var drugTypesList = _mapper.AutoMapper.Map<IEnumerable<DrugType>, List<DrugTypeDto>>(drugTypes);
            return drugTypesList;
        }
    }
}