using System.Collections.Generic;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;

namespace Suvoda.TechnicalTest.BLL.Dto.DrugTypes
{
    public class DrugTypeDto
    {
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public decimal Weight { get; set; }

        public virtual ICollection<DrugUnitDto> DrugUnits { get; set; }
    }
}
