using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;

namespace Suvoda.TechnicalTest.Models
{
    public class AvailableUnitsCalcViewModel
    {
        public DrugType DrugType { get; set; }
        public int UnitsNeededCount { get; set; }
        public List<DrugUnit> ResultDrugUnits { get; set; }
    }
}