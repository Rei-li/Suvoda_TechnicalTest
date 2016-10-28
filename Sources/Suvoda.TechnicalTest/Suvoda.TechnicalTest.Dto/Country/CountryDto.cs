using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.Dto.DepotDestination;
using Suvoda.TechnicalTest.Dto.Depots;

namespace Suvoda.TechnicalTest.Dto.Country
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        
        public virtual ICollection<DepotDto> Depots { get; set; }
        public virtual ICollection<DepotDestinationDto> DepotDestinations { get; set; }
    }
}
