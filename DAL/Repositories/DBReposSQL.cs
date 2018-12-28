using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DbReposSQL : IUnitOfWork
    {
        private VkladDb db;
        private ClientRepository clientRepository;
        private VkladRepository vkladrRepository;
        private ProgRepository progRepository;

        public DbReposSQL()
        {
            db = new VkladDb();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IVkladRepository Vklads
        {
            get
            {
                if (vkladrRepository == null)
                    vkladrRepository = new VkladRepository(db);
                return vkladrRepository;
            }
        }

        public IRepository<Prog> Progs
        {
            get
            {
                if (progRepository == null)
                    progRepository = new ProgRepository(db);
                return progRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
