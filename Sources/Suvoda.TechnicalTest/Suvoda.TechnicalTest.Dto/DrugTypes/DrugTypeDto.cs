using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.Dto.DrugUnits;

namespace Suvoda.TechnicalTest.Dto.DrugTypes
{
    public class DrugTypeDto
    {
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public decimal Weight { get; set; }

        public virtual ICollection<DrugUnitDto> DrugUnits { get; set; }
    }
}
