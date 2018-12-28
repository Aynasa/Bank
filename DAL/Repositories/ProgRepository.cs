using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProgRepository : IRepository<Prog>
    {
        private VkladDb db;

        public ProgRepository(VkladDb dbcontext)
        {
            this.db = dbcontext;
        }
        
        public ObservableCollection<Prog> GetList()
        {
            db.Progs.Load();
            return db.Progs.Local;
        }

        public Prog GetItem(int id)
        {
            return db.Progs.Find(id);
        }

        public void Create(Prog item)
        {
            db.Progs.Add(item);
        }

        public void Update(Prog item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Prog item = db.Progs.Find(id);
            if (item != null)
                db.Progs.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
