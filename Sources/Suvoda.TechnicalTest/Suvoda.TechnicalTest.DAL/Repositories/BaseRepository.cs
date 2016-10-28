using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suvoda.TechnicalTest.DAL.Repositories
{
    public class BaseRepository : DbContext
    {
        protected suvodaEntities db = new suvodaEntities();

        public void Save<T>(T entity) where T : class
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
