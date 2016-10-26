using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suvoda.TechnicalTest.Models
{
    public class DepotViewModel
    {
        public int DepotId { get; set; }

        [Display(Name = "Depot Name")]
        public string DepotName { get; set; }

        [Display(Name = "Country Name")]
        public string DepotLocation { get; set; }

        [Display(Name = "Drug Type Name")]
        public string DrugTypeName { get; set; }

        [Display(Name = "Drug Unit Id")]
        public int? DrugUnitId { get; set; }

        [Display(Name = "Pick Number")]
        public int? PickNumber { get; set; }
    }
}