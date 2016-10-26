using System.Web.Mvc;
using Suvoda.TechnicalTest.BLL;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DepotsController : Controller
    {
        private DepotsBlo depotsBlo = new DepotsBlo();
        private DrugTypesBlo drugTypesBlo = new DrugTypesBlo();
        private DrugUnitsBlo drugUnitsBlo = new DrugUnitsBlo();


        // GET: Depots
        public ActionResult Index()
        {
            var depots = depotsBlo.GetDepotsViewList();
            return View(depots);
        }
        
        public ActionResult DepotAvailableUnitsCalculation()
        {
            var depots = depotsBlo.GetDepotsViewList();
            var model = new DepotSelectionViewModel();
            model.DepotsList = new SelectList(depots, "DepotId", "DepotName", model.SelectedDepotId);
            return View(model);
        }

       
        [HttpPost]
        public ActionResult AvailableUnits(DepotSelectionViewModel model)
        {
            var drugTypes = drugTypesBlo.GetDrugTypes();
            return PartialView(drugTypes);
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
        
    }
}
