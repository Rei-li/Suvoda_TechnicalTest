using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suvoda.TechnicalTest.Helpers
{
    public static class WeightConverter
    {
        const decimal PondsInKg = (decimal)2.2;

        public static decimal ConvertPoundsToKg(decimal pondsValue)
        {
            return pondsValue/PondsInKg;
        }
    }
}