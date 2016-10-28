using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.Dto.Country;
using Suvoda.TechnicalTest.Dto.DepotDestination;
using Suvoda.TechnicalTest.Dto.DrugUnits;

namespace Suvoda.TechnicalTest.Dto.Depots
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
