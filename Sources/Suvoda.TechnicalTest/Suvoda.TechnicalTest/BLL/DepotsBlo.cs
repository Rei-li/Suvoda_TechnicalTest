using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;
using System.Data.Entity;
using Suvoda.TechnicalTest.Helpers;
using Suvoda.TechnicalTest.Models;
using WebGrease.Css.Ast.Selectors;

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


        public List<IEnumerable<DepotStockViewModel>> GetDepotsAssortment()
        {
            var depots = db.Depots;

            return (from depot in depots
                    where depot.DrugUnits.Any()
                    select (from unit in depot.DrugUnits
                            group unit by unit.DrugType
                        into typeGroup
                            select new DepotStockViewModel
                            {
                                DepotId = depot.DepotId,
                                DepotName = depot.DepotName,
                                DrugTypeId = typeGroup.Key.DrugTypeId,
                                DrugTypeName = typeGroup.Key.DrugTypeName,
                                DrugUnitsWeight = typeGroup.Sum(x => x.DrugType.Weight),
                            })).ToList();

        }


    }

}