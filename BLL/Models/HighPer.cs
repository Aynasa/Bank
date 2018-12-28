using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class HighPer
    {
        public HighPer(decimal val)
        {
            _value = val;
        }

        private decimal _value = 0;
        public decimal Value { get { return _value; } }

        public decimal GetDiscountedPrice(decimal sum)
        {
            if ((DateTime.Now.Day == 1)&& (DateTime.Now.Day == DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month)))
                return sum + _value;
            return sum;
        }
    }
}
