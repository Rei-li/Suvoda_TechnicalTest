using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;
using Suvoda.TechnicalTest.BLL.Services.Depots;
using Suvoda.TechnicalTest.BLL.Services.DrugUnits;
using Suvoda.TechnicalTest.Mappings;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.Controllers
{
    public class DrugUnitsController : Controller
    {
        private IDrugUnitsService _drugUnitsService;
        private IDepotsService _depotsService;
        private IMapper _mapper = DtoModelMapper.RegisterMappings();

        public DrugUnitsController(IDepotsService depotsService, IDrugUnitsService drugUnitsService)
        {
            _depotsService = depotsService;
            _drugUnitsService = drugUnitsService;
        }


        // GET: DrugUnits
        public ActionResult Index()
        {
            var drugUnits = _drugUnitsService.GetDrugUnits();
            var drugUnitModels = _mapper.Map<IEnumerable<DrugUnitDto>, List<DrugUnitsViewModel>>(drugUnits);
            return View(drugUnitModels);
        }
        
        // GET: DrugUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugUnit = _drugUnitsService.GetDrugUnitById(id);
            if (drugUnit == null)
            {
                return HttpNotFound();
            }
            var drugUnitModel = _mapper.Map<DrugUnitDto, DrugUnitsViewModel>(drugUnit);
            LookupDto lookup;
            ViewBag.DepotId = new SelectList(_depotsService.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnit.DepotId);
            return View(drugUnitModel);
        }

        // POST: DrugUnits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugUnitId,PickNumber,DrugTypeId,DepotId")] DrugUnitsViewModel drugUnitModel)
        {
            if (ModelState.IsValid)
            {
                var drugUnitDto = _mapper.Map<DrugUnitsViewModel, DrugUnitDto>(drugUnitModel);

                _drugUnitsService.Save(drugUnitDto);
                return RedirectToAction("Index");
            }
            
            LookupDto lookup;
            ViewBag.DepotId = new SelectList(_depotsService.GetDepotLookup(), nameof(lookup.Key), nameof(lookup.Value), drugUnitModel.DepotId);
            return View(drugUnitModel);
        }

        
    }
}
