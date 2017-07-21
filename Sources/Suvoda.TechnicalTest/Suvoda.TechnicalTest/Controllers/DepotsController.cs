using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
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
        private IDtoModelMapper _mapper;

        public DepotsController(IDepotsService depotsService, IDrugTypesService drugTypesService, IDrugUnitsService drugUnitsService, IDtoModelMapper dtoModelMapper)
        {
            _depotsService = depotsService;
            _drugTypesService = drugTypesService;
            _drugUnitsService = drugUnitsService;
            _mapper = dtoModelMapper;
        }

        // GET: Depots
        public ActionResult Index()
        {
            var depotDtos = _depotsService.GetDepotsViewList();
            var lookup = _mapper.AutoMapper.Map<IEnumerable<DepotViewDto>, IEnumerable<DepotViewModel>>(depotDtos);
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
            var drugTypesModels = _mapper.AutoMapper.Map<IEnumerable<DrugTypeDto>, IEnumerable<DrugTypeViewModel>>(drugTypes);
            return PartialView(drugTypesModels);
        }

        [HttpPost]
        public ActionResult GetUnitsForShipment(int count, int type, int depot)
        {
            var drugUnits = _drugUnitsService.GetUnitsForShipment(count, type, depot).ToList();
            var drugUnitsModels = _mapper.AutoMapper.Map<IEnumerable<DrugUnitDto>, IEnumerable<DrugUnitsViewModel>>(drugUnits);
            return Json(drugUnitsModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Stock()
        {
            var depots = _depotsService.GetDepotsAssortment();
            var stockModels = _mapper.AutoMapper.Map<IEnumerable<IEnumerable<DepotStockDto>>, IEnumerable<IEnumerable<DepotStockViewModel>>>(depots.ToList());
            return View(stockModels);
        }

    }
}
