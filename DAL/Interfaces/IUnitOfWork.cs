using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> Clients { get; }
        IVkladRepository Vklads { get; }
        IRepository<Prog> Progs { get; }
        int Save();
    }
}
