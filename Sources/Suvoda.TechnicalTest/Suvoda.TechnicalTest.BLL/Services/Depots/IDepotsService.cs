using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.BLL.Dto;
using Suvoda.TechnicalTest.BLL.Dto.Depots;

namespace Suvoda.TechnicalTest.BLL.Services.Depots
{
    public interface IDepotsService
    {
        IEnumerable<DepotViewDto> GetDepotsViewList();
        IEnumerable<LookupDto> GetDepotLookup();
        List<IEnumerable<DepotStockDto>> GetDepotsAssortment();
    }
}
