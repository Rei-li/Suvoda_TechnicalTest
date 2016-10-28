﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvoda.TechnicalTest.DAL.Repositories.DrugTypes
{
    interface IDrugTypesRepository
    {
        IEnumerable<DrugType> GetDrugTypes();
    }
}
