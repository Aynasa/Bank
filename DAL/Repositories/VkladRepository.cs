using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VkladRepository : IVkladRepository
    {
        private VkladDb db;

        public VkladRepository(VkladDb dbcontext)
        {
            this.db = dbcontext;
            db.Vklads.Load();
        }

        public System.Collections.ObjectModel.ObservableCollection<Vklad> GetList()
        {
            return db.Vklads.Local;
        }

        public Vklad GetItem(int id)
        {
            return db.Vklads.Find(id);
        }

        public void Create(Vklad Order)
        {
            db.Vklads.Add(Order);
        }

        public void Update(Vklad order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Vklad Vklad = db.Vklads.Find(id);
            if (Vklad != null)
                db.Vklads.Remove(Vklad);
        }

        public List<SPVklad> VkladsByMonth(DateTime date)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@data", date.Date);

            db = new VkladDb();
            var result = db.Database.SqlQuery<SPVklad>("pr_report @data", new object[] { param }).ToList();

            return result;
        }

        
    }
}
