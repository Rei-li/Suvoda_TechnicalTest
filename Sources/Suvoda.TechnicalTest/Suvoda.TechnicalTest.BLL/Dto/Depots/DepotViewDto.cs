namespace Suvoda.TechnicalTest.BLL.Dto.Depots
{
    public class DepotViewDto
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public string DepotLocation { get; set; }
        public string DrugTypeName { get; set; }
        public int? DrugUnitId { get; set; }
        public int? PickNumber { get; set; }
    }
}
