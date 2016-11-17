using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suvoda.TechnicalTest.Models
{
    public class DrugUnitsApiModel
    {
        public int DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public int? DepotId { get; set; }
        public string DepotName { get; set; }

    }
}