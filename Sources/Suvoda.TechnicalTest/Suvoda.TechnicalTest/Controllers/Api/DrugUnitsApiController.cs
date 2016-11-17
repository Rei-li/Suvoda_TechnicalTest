using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/units")]
    public class DrugUnitsApiController : ApiController
    {
        private readonly IDrugUnitsService _drugUnitsService;
        private readonly IDtoModelMapper _mapper;

        public DrugUnitsApiController( IDrugUnitsService drugUnitsService, IDtoModelMapper dtoModelMapper)
        {
            _drugUnitsService = drugUnitsService;
            _mapper = dtoModelMapper;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IEnumerable<DrugUnitsApiModel> Index()
        {
            var drugUnits = _drugUnitsService.GetDrugUnits();
            var drugUnitModels = _mapper.AutoMapper.Map<IEnumerable<DrugUnitDto>, IEnumerable<DrugUnitsApiModel>>(drugUnits);
            return drugUnitModels;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id:int}")]
        public DrugUnitsApiModel Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var drugUnit = _drugUnitsService.GetDrugUnitById(id);
            if (drugUnit == null)
            {
                return null;
            }
            var drugUnitModel = _mapper.AutoMapper.Map<DrugUnitDto, DrugUnitsApiModel>(drugUnit);
            return drugUnitModel;
        }


        [System.Web.Http.Route("{unitId:int}")]
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public void EditDepotAssigned([FromBody] DrugUnitsApiModel drugUnitModel)
        {
            if (ModelState.IsValid)
            {
                var drugUnitDto = _mapper.AutoMapper.Map<DrugUnitsApiModel, DrugUnitDto>(drugUnitModel);

                _drugUnitsService.Save(drugUnitDto);

            }
        }

    }
}
