using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Suvoda.TechnicalTest.DAL;

namespace Suvoda.TechnicalTest.BLL
{
    public class BloBase 
    {
        protected Repository db = new Repository();



        public void Save<T>(T entity) where T : class
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}