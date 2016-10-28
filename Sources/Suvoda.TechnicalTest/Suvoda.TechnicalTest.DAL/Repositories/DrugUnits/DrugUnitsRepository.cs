using System.Collections.Generic;

namespace Suvoda.TechnicalTest.DAL.Repositories.DrugUnits
{
    public class DrugUnitsRepository: BaseRepository, IDrugUnitsRepository
    {
        /// <summary>
        /// Get all drug units
        /// </summary>
        /// <returns>List of drug units</returns>
        public IEnumerable<DrugUnit> GetDrugUnits()
        {
            return db.DrugUnits;
        }
        
        public DrugUnit GetDrugUnitById(int? id)
        {
            return db.DrugUnits.Find(id);
        }

        public void Save(DrugUnit entity)
        {
            base.Save<DrugUnit>(entity);
        }

    }
}
