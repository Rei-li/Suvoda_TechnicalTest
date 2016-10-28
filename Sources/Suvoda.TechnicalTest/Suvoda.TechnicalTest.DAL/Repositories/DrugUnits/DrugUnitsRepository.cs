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

        /// <summary>
        /// Get drug unit by Id
        /// </summary>
        /// <param name="id">identificator of drug unit </param>
        /// <returns>drug unit with certain Id</returns>
        public DrugUnit GetDrugUnitById(int? id)
        {
            return db.DrugUnits.Find(id);
        }

        /// <summary>
        /// Save drug unit
        /// </summary>
        /// <param name="entity">drug unit to save</param>
        public void Save(DrugUnit entity)
        {
            base.Save(entity);
        }

    }
}
