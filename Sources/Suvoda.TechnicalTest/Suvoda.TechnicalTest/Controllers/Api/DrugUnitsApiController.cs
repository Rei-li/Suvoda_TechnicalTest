using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.BLL.Services.Depots;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/units")]
    public class DrugUnitsApiController : ApiController
    {
        private IDrugUnitsService _drugUnitsService;
       // private IDepotsService _depotsService;
        private IDtoModelMapper _mapper;

        public DrugUnitsApiController( IDrugUnitsService drugUnitsService, IDtoModelMapper dtoModelMapper)
        {
           // _depotsService = depotsService;
            _drugUnitsService = drugUnitsService;
            _mapper = dtoModelMapper;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IEnumerable<DrugUnitsViewModel> Index()
        {
            var drugUnits = _drugUnitsService.GetDrugUnits();
            var drugUnitModels = _mapper.AutoMapper.Map<IEnumerable<DrugUnitDto>, IEnumerable<DrugUnitsViewModel>>(drugUnits);
            return drugUnitModels;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id:int}")]
        public DrugUnitsViewModel Edit(int? id)
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
            var drugUnitModel = _mapper.AutoMapper.Map<DrugUnitDto, DrugUnitsViewModel>(drugUnit);
            //LookupDto lookup;
            //ViewBag.DepotId = new SelectList(_depotsService.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnit.DepotId);
            return drugUnitModel;
        }


        [System.Web.Http.Route("{id:int}")]
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public void Edit([FromBody] DrugUnitsViewModel drugUnitModel)
        {
            if (ModelState.IsValid)
            {
                var drugUnitDto = _mapper.AutoMapper.Map<DrugUnitsViewModel, DrugUnitDto>(drugUnitModel);

                _drugUnitsService.Save(drugUnitDto);
               
            }

            //LookupDto lookup;
            //ViewBag.DepotId = new SelectList(_depotsService.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnitModel.DepotId);
          //  return View(drugUnitModel);
        }

    }
}
