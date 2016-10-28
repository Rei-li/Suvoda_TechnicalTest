using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services.Depots;
using Suvoda.TechnicalTest.BLL.Services.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DepotsController : Controller
    {
        private IDepotsService _depotsService;
        private IDrugTypesService _drugTypesService;
        private IDrugUnitsService _drugUnitsService;
        private IMapper _mapper = DtoModelMapper.RegisterMappings();

        public DepotsController(IDepotsService depotsService, IDrugTypesService drugTypesService, IDrugUnitsService drugUnitsService)
        {
            _depotsService = depotsService;
            _drugTypesService = drugTypesService;
            _drugUnitsService = drugUnitsService;
        }

        // GET: Depots
        public ActionResult Index()
        {
            var depotDtos = _depotsService.GetDepotsViewList();
            var lookup = _mapper.Map<IEnumerable<DepotViewDto>, List<DepotViewModel>>(depotDtos);
            return View(lookup);
        }

        public ActionResult DepotAvailableUnitsCalculation()
        {
            var depots = _depotsService.GetDepotLookup();
            var model = new DepotSelectionViewModel();

            LookupDto lookup;
            model.DepotsList = new SelectList(depots, nameof(lookup.Key), nameof(lookup.Value), model.SelectedDepotId);
            return View(model);
        }


        [HttpPost]
        public ActionResult AvailableUnits(DepotSelectionViewModel model)
        {
            var drugTypes = _drugTypesService.GetDrugTypes();
            var drugTypesModels = _mapper.Map<IEnumerable<DrugTypeDto>, List<DrugTypeViewModel>>(drugTypes);
            return PartialView(drugTypesModels);
        }

        [HttpPost]
        public ActionResult GetAvailableUnit(int count, int type, int depot)
        {
            var drugUnit = _drugUnitsService.GetDepotAvailableUnit(count, type, depot);
            var result = 0;
            if (drugUnit != null)
            {
                result = drugUnit.DrugUnitId;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Stock()
        {
            var depots = _depotsService.GetDepotsAssortment();
            var stockModels = _mapper.Map<List<IEnumerable<DepotStockDto>>, List<IEnumerable<DepotStockViewModel>>>(depots);
            return View(stockModels);
        }
        
    }
}
