using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;

namespace Suvoda.TechnicalTest.BLL
{
    public class DrugTypesBlo : BloBase
    {
        /// <summary>
        /// Get all drug types
        /// </summary>
        /// <returns>list of drug types </returns>
        public List<DrugType> GetDrugTypes()
        {
            var drugTypes = db.DrugTypes;
            return drugTypes.ToList();
        }
    }
}