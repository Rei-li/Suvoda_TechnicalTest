using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvoda.TechnicalTest.DAL.Repositories.DrugUnits
{
    public interface IDrugUnitsRepository
    {
        IEnumerable<DrugUnit> GetDrugUnits();
        DrugUnit GetDrugUnitById(int? id);
        void Save(DrugUnit entity);
    }
}
