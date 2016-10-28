using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvoda.TechnicalTest.Dto.Depots
{
    public class DepotStockDto
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public decimal DrugUnitsWeight { get; set; }
       
    }
}
