using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.Dto.Depots;

namespace Suvoda.TechnicalTest.Models
{
    public class DrugUnitsViewModel
    {
        public int DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public int DrugTypeId { get; set; }
        public int? DepotId { get; set; }

        public DepotDto Depot { get; set; }
        public DrugTypeViewModel DrugType { get; set; }
    }
}