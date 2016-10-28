using Suvoda.TechnicalTest.BLL.Dto.Country;
using Suvoda.TechnicalTest.BLL.Dto.Depots;

namespace Suvoda.TechnicalTest.BLL.Dto.DepotDestination
{
    public class DepotDestinationDto
    {
        public int DepotId { get; set; }
        public int CountryId { get; set; }
        public int Id { get; set; }

        public virtual CountryDto Country { get; set; }
        public virtual DepotDto Depot { get; set; }
    }
}
