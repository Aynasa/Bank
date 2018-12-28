using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class SPVklad
    {
           
        public DateTime DateOpen { get; set; }
        public int Balance { get; set; }
       
    }
}
