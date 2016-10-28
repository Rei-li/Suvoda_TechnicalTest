using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Suvoda.TechnicalTest.BLL;
using Suvoda.TechnicalTest.BLL.Services;
using Suvoda.TechnicalTest.Dto;
using Suvoda.TechnicalTest.Dto.Depots;
using Suvoda.TechnicalTest.Dto.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DrugUnitsController : Controller
    {
        private DrugUnitsBlo drugUnitsBlo = new DrugUnitsBlo();
        private DepotsBlo depotsBlo = new DepotsBlo();
        private IMapper mapper = DtoModelMapper.RegisterMappings();


        // GET: DrugUnits
        public ActionResult Index()
        {
            var drugUnits = drugUnitsBlo.GetDrugUnits();
            var drugUnitModels = mapper.Map<IEnumerable<DrugUnitDto>, List<DrugUnitsViewModel>>(drugUnits);
            return View(drugUnitModels);
        }
        
        // GET: DrugUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugUnit = drugUnitsBlo.GetDrugUnitById(id);
            if (drugUnit == null)
            {
                return HttpNotFound();
            }
            var drugUnitModel = mapper.Map<DrugUnitDto, DrugUnitsViewModel>(drugUnit);
            LookupDto lookup;
            ViewBag.DepotId = new SelectList(depotsBlo.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnit.DepotId);
            return View(drugUnitModel);
        }

        // POST: DrugUnits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugUnitId,PickNumber,DrugTypeId,DepotId")] DrugUnitsViewModel drugUnitModel)
        {
            if (ModelState.IsValid)
            {
                var drugUnitDto = mapper.Map<DrugUnitsViewModel, DrugUnitDto>(drugUnitModel);

                drugUnitsBlo.Save(drugUnitDto);
                return RedirectToAction("Index");
            }
            
            LookupDto lookup;
            ViewBag.DepotId = new SelectList(depotsBlo.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnitModel.DepotId);
            return View(drugUnitModel);
        }

        
    }
}
