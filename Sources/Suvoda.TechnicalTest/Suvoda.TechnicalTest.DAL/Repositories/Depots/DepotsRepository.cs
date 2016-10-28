using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Suvoda.TechnicalTest.DAL.Repositories.Depots
{
    public class DepotsRepository: BaseRepository, IDepotsRepository
    {
        /// <summary>
        /// Get all depots
        /// </summary>
        /// <returns>list of depots </returns>
        public IEnumerable<Depot> GetDepots()
        {
            return db.Depots;
        }


    }
}
