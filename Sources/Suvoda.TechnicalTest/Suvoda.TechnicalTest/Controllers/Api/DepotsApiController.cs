using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services.Depots;
using Suvoda.TechnicalTest.BLL.Services.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers.Api
{

    [System.Web.Http.RoutePrefix("api/depots")]
    public class DepotsApiController : ApiController
    {
        private IDepotsService _depotsService;
        private IDrugTypesService _drugTypesService;
        private IDrugUnitsService _drugUnitsService;
        private IDtoModelMapper _mapper;


        public DepotsApiController(IDepotsService depotsService, IDrugTypesService drugTypesService, IDrugUnitsService drugUnitsService, IDtoModelMapper dtoModelMapper)
        {
            _depotsService = depotsService;
            _drugTypesService = drugTypesService;
            _drugUnitsService = drugUnitsService;
            _mapper = dtoModelMapper;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IEnumerable<DepotViewModel> Index()
        {
            var depotDtos = _depotsService.GetDepotsViewList();
            var modelsList = _mapper.AutoMapper.Map<IEnumerable<DepotViewDto>, IEnumerable<DepotViewModel>>(depotDtos);
            return modelsList;


        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("lookup")]
        public DepotSelectionViewModel DepotAvailableUnitsCalculation()
        {
            var depots = _depotsService.GetDepotLookup();
            var model = new DepotSelectionViewModel();

            LookupDto lookup;
            model.DepotsList = new SelectList(depots, nameof(lookup.Key), nameof(lookup.Value), model.SelectedDepotId);
            return model;
        }


        [System.Web.Http.Route("types")]
        [System.Web.Http.HttpPost]
        public IEnumerable<DrugTypeViewModel> AvailableUnits(DepotSelectionViewModel model)
        {
            var drugTypes = _drugTypesService.GetDrugTypes();
            var drugTypesModels = _mapper.AutoMapper.Map<IEnumerable<DrugTypeDto>, IEnumerable<DrugTypeViewModel>>(drugTypes);
            return drugTypesModels;
        }

        [System.Web.Http.Route("{depot:int}/available")]
        [System.Web.Http.HttpPost]
        public int GetAvailableUnit(int count, int type, int depot)
        {
            var drugUnit = _drugUnitsService.GetDepotAvailableUnit(count, type, depot);
            var result = 0;
            if (drugUnit != null)
            {
                result = drugUnit.DrugUnitId;
            }
            return result;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("stock")]
        public IEnumerable<IEnumerable<DepotStockViewModel>> Stock()
        {
            var depots = _depotsService.GetDepotsAssortment();
            var stockModels = _mapper.AutoMapper.Map<IEnumerable<IEnumerable<DepotStockDto>>, IEnumerable<IEnumerable<DepotStockViewModel>>>(depots.ToList());
            return stockModels;
        }
    }
}
