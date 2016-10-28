using System.Collections.Generic;
using Suvoda.TechnicalTest.BLL.Dto.Country;
using Suvoda.TechnicalTest.BLL.Dto.DepotDestination;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;

namespace Suvoda.TechnicalTest.BLL.Dto.Depots
{
    public class DepotDto
    {
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public int DepotLocation { get; set; }

        public virtual CountryDto Country { get; set; }
     
        public virtual ICollection<DepotDestinationDto> DepotDestinations { get; set; }
       
        public virtual ICollection<DrugUnitDto> DrugUnits { get; set; }

    }
}
