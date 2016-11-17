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
        private IDtoModelMapper _mapper;


        public DepotsApiController(IDepotsService depotsService, IDtoModelMapper dtoModelMapper)
        {
            _depotsService = depotsService;
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
        public DepotSelectionViewModel GetDepotLookup()
        {
            var depots = _depotsService.GetDepotLookup();
            var model = new DepotSelectionViewModel();

            LookupDto lookup;
            model.DepotsList = new SelectList(depots, nameof(lookup.Key), nameof(lookup.Value), model.SelectedDepotId);
            return model;
        }
        
    }
}
