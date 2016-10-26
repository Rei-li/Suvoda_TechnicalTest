using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suvoda.TechnicalTest.Models
{
    public class DepotSelectionViewModel
    {
        public int? SelectedDepotId { get; set; }
        public SelectList DepotsList { get; set; }
    }
}