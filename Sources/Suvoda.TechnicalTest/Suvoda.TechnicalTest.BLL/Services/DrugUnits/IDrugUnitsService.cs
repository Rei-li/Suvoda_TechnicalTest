﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suvoda.TechnicalTest.BLL.Dto.DrugUnits;

namespace Suvoda.TechnicalTest.BLL.Services.DrugUnits
{
    public interface IDrugUnitsService
    {
        IEnumerable<DrugUnitDto> GetDrugUnits();
        DrugUnitDto GetDepotAvailableUnit(int pickNumber, int drugTypeId, int depotId);
        DrugUnitDto GetDrugUnitById(int? id);
        void Save(DrugUnitDto dto);
    }
}
