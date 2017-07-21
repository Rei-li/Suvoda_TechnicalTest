using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suvoda.TechnicalTest.Models
{
    public class DrugTypeViewModel
    {
        public int DrugTypeId { get; set; }

        [Display(Name = "Drug Type")]
        public string DrugTypeName { get; set; }

        public decimal Weight { get; set; }

    }
}