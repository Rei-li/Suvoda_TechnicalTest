using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;

namespace Suvoda.TechnicalTest.BLL.Services.DrugTypes
{
    public interface IDrugTypesService
    {
        IEnumerable<DrugTypeDto> GetDrugTypes();
    }
}
