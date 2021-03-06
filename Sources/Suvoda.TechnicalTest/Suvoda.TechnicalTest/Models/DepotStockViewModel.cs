﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.Helpers;

namespace Suvoda.TechnicalTest.Models
{
    public class DepotStockViewModel
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public decimal DrugUnitsWeight { get; set; }
    }
}