using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvoda.TechnicalTest.DAL.Repositories.DrugTypes
{
    public class DrugTypesRepository : BaseRepository, IDrugTypesRepository
    {
        /// <summary>
        /// Get all drug types
        /// </summary>
        /// <returns>list of drug types </returns>
        public IEnumerable<DrugType> GetDrugTypes()
        {
            return db.DrugTypes;
        }
    }
}
