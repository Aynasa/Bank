using System;
using BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        List<SPResult> ExecuteSP(DateTime date);
    }
}
