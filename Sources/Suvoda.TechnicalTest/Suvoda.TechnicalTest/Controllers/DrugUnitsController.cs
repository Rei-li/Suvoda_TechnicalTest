using System.Net;
using System.Web.Mvc;
using Suvoda.TechnicalTest.BLL;
using Suvoda.TechnicalTest.DAL;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DrugUnitsController : Controller
    {
        private DrugUnitsBlo drugUnitsBlo = new DrugUnitsBlo();
        private DepotsBlo depotsBlo = new DepotsBlo();

        // GET: DrugUnits
        public ActionResult Index()
        {
            var drugUnits = drugUnitsBlo.GetDrugUnits();
            return View(drugUnits);
        }
        
        // GET: DrugUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugUnit drugUnit = drugUnitsBlo.GetDrugUnitById(id);
            if (drugUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepotId = new SelectList(depotsBlo.GetDepots(), nameof(drugUnit.DepotId) , nameof(drugUnit.Depot.DepotName), drugUnit.DepotId);
            return View(drugUnit);
        }

        // POST: DrugUnits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugUnitId,PickNumber,DrugTypeId,DepotId")] DrugUnit drugUnit)
        {
            if (ModelState.IsValid)
            {
                drugUnitsBlo.Save(drugUnit);
                return RedirectToAction("Index");
            }
            ViewBag.DepotId = new SelectList(depotsBlo.GetDepots(), nameof(drugUnit.DepotId), nameof(drugUnit.Depot.DepotName), drugUnit.DepotId);
            return View(drugUnit);
        }

        
    }
}
