using BLL.Interfaces;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VkladService : IVkladService
    {
        private DAL.Interfaces.IUnitOfWork db;
        
        public VkladService(DAL.Interfaces.IUnitOfWork db)
        {
            this.db = db;
        }
        Vklad vklad;
        public bool MakeRecord(VkladMod vkladDto)
        {


            if (vkladDto.Id > 0)
            {
                Vklad vklad = db.Vklads.GetItem(vkladDto.Id);
                vklad.DateOpen = DateTime.Now;
                vklad.Balance = 0;

                vklad.Client_FK = vkladDto.ClientId;
                vklad.Prog_FK = vkladDto.ProgId;
                db.Vklads.Update(vklad);
            }
            else
            {
                vklad = new Vklad
                {
                    Balance = 0,
                    DateOpen = DateTime.Now,
                    Client_FK = vkladDto.ClientId,
                    Prog_FK = vkladDto.ProgId
                };
                db.Vklads.Create(vklad);
            }
            bool res = db.Save() > 0;
            return res;
        }
    }
}