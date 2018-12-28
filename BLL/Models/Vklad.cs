using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class VkladMod
    {

        public int Balance { get; set; }

        public DateTime DateOpen { get; set; }



        public int Percent { get; set; }
        public string Prog_name { get; set; }

        public int ClientId { get; set; }
        public int ProgId { get; set; }
        public int Id { get; set; }






    }
}
