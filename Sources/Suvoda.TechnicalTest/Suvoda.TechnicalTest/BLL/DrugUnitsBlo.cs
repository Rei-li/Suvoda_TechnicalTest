using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;
using System.Data.Entity;

namespace Suvoda.TechnicalTest.BLL
{
    public class DrugUnitsBlo : BloBase
    {
        /// <summary>
        /// Get all drug units
        /// </summary>
        /// <returns>List of drug units</returns>
        public List<DrugUnit> GetDrugUnits()
        {
            var drugUnits = db.DrugUnits.Include(d => d.Depot).Include(d => d.DrugType);
            return drugUnits.ToList();
        }

        /// <summary>
        /// Get first suitable drug unit of certain type from certain depot with certain pickNumber
        /// </summary>
        /// <param name="pickNumber">number of units needed</param>
        /// <param name="drugTypeId">id of drug type</param>
        /// <param name="depotId">id of depot</param>
        /// <returns>first suitable drug unit according to  type, depot and pickNumber </returns>
        public DrugUnit GetDepotAvailableUnit(int pickNumber, int drugTypeId, int depotId)
        {
            return db.DrugUnits.FirstOrDefault(x => x.PickNumber == pickNumber && x.DrugType.DrugTypeId == drugTypeId && x.DepotId == depotId);
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