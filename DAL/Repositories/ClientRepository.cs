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
    public class ClientRepository : IRepository<Client>
    {
        private VkladDb db;


        public ClientRepository(VkladDb dbcontext)
        {
            this.db = dbcontext;
            db.Clients.Load();
            
        }

        public ObservableCollection<Client> GetList()
        {
            return db.Clients.Local;
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public void Create(Client c)
        {
            db.Clients.Add(c);
        }

        public void Update(Client c)
        {
            db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client Client = db.Clients.Find(id);
            if (Client != null)
                db.Clients.Remove(Client);
        }

    }
}
