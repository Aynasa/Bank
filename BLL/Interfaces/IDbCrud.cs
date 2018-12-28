using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<ClientMod> GetAllClients();
        List<VkladMod> GetAllVklads();
      //  ClientMod GetClient(int Id);
        //VkladMod GetVklad(int Id);
        void CreateVklad(VkladMod c);
        void UpdateVklad(VkladMod c);        
        void DeleteClient(int id);
        void DeleteVklad(int id);
        List<ProgMod> GetProgs();
    }
}
