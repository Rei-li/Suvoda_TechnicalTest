using Suvoda.TechnicalTest.BLL.Dto.Depots;
using Suvoda.TechnicalTest.BLL.Dto.DrugTypes;

namespace Suvoda.TechnicalTest.BLL.Dto.DrugUnits
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
