using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services
{
    public class ReportServices : IReportService
    {
        private VkladDb db;



        public List<SPResult> ExecuteSP(DateTime date)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@data", date.Date);

            db = new VkladDb();
            var result = db.Database.SqlQuery<SPResult>("lab31111 @data", new object[] { param }).ToList();

            return result;
        }


    }
}
