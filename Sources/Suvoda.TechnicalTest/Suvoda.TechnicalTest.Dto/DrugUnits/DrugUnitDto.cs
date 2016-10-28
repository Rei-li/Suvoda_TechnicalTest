using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.Dto.Depots;
using Suvoda.TechnicalTest.Dto.DrugTypes;

namespace Suvoda.TechnicalTest.Dto.DrugUnits
{
    public class DrugUnitDto
    {
        public int DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public int DrugTypeId { get; set; }
        public int? DepotId { get; set; }

        public  DepotDto Depot { get; set; }
        public  DrugTypeDto DrugType { get; set; }
    }
}
