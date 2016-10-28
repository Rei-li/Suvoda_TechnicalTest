using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;
using Suvoda.TechnicalTest.BLL.Services;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DepotsController : Controller
    {
        private DepotsService depotsBlo = new DepotsService();
        private DrugTypesService drugTypesBlo = new DrugTypesService();
        private DrugUnitsService drugUnitsBlo = new DrugUnitsService();
        private IMapper mapper = DtoModelMapper.RegisterMappings();


        // GET: Depots
        public ActionResult Index()
        {
            var depotDtos = depotsBlo.GetDepotsViewList();
            var lookup = mapper.Map<IEnumerable<DepotViewDto>, List<DepotViewModel>>(depotDtos);
            return View(lookup);
        }

        public ActionResult DepotAvailableUnitsCalculation()
        {
            var depots = depotsBlo.GetDepotLookup();
            var model = new DepotSelectionViewModel();

            LookupDto lookup;
            model.DepotsList = new SelectList(depots, nameof(lookup.Key), nameof(lookup.Value), model.SelectedDepotId);
            return View(model);
        }


        [HttpPost]
        public ActionResult AvailableUnits(DepotSelectionViewModel model)
        {
            var drugTypes = drugTypesBlo.GetDrugTypes();
            var drugTypesModels = mapper.Map<IEnumerable<DrugTypeDto>, List<DrugTypeViewModel>>(drugTypes);
            return PartialView(drugTypesModels);
        }

        [HttpPost]
        public ActionResult GetAvailableUnit(int count, int type, int depot)
        {
            var drugUnit = drugUnitsBlo.GetDepotAvailableUnit(count, type, depot);
            var result = 0;
            if (drugUnit != null)
            {
                result = drugUnit.DrugUnitId;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Stock()
        {
            var depots = depotsBlo.GetDepotsAssortment();
            var stockModels = mapper.Map<List<IEnumerable<DepotStockDto>>, List<IEnumerable<DepotStockViewModel>>>(depots);
            return View(stockModels);
        }
        
    }
}
