using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;
using System.Data.Entity;
using Suvoda.TechnicalTest.Models;

namespace Suvoda.TechnicalTest.BLL
{
    public class DepotsBlo : BloBase
    {
        /// <summary>
        /// Get depots with drug units from that depot
        /// </summary>
        /// <returns>list of depots to display</returns>
        public List<DepotViewModel> GetDepotsViewList()
        {
            List<DepotViewModel> models = new List<DepotViewModel>();
            var depots = db.Depots.Include(d => d.Country);
            foreach (var depot in depots)
            {
                if (depot.DrugUnits.Any())
                {
                    models.AddRange(depot.DrugUnits.Select(drugUnit => new DepotViewModel()
                    {
                        DepotId = depot.DepotId,
                        DepotName = depot.DepotName,
                        DepotLocation = depot.Country.CountryName,
                        DrugUnitId = drugUnit.DrugUnitId,
                        PickNumber = drugUnit.PickNumber,
                        DrugTypeName = drugUnit.DrugType.DrugTypeName
                    }));
                }
                else
                {
                    var depotModel = new DepotViewModel()
                    {
                        DepotId = depot.DepotId,
                        DepotName = depot.DepotName,
                        DepotLocation = depot.Country.CountryName
                    };

                    models.Add(depotModel);
                }

            }


            return models;
        }

        /// <summary>
        /// Get all depots
        /// </summary>
        /// <returns>list of depots </returns>
        public List<Depot> GetDepots()
        {
            var depots = db.Depots;
            return depots.ToList();
        }


    }
    
}