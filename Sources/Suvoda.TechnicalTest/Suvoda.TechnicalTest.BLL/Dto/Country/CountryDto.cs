using System.Collections.Generic;
using Suvoda.TechnicalTest.BLL.Dto.DepotDestination;
using Suvoda.TechnicalTest.BLL.Dto.Depots;

namespace Suvoda.TechnicalTest.BLL.Dto.Country
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        
        public virtual ICollection<DepotDto> Depots { get; set; }
        public virtual ICollection<DepotDestinationDto> DepotDestinations { get; set; }
    }
}
