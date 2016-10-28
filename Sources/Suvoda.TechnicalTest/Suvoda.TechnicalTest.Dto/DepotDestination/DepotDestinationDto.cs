using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.Dto.Country;
using Suvoda.TechnicalTest.Dto.Depots;

namespace Suvoda.TechnicalTest.Dto.DepotDestination
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
