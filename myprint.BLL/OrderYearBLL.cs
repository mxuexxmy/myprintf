using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.BLL
{
    public interface OrderYearBLL
    {
        PageInfo<OrderYear> page(int start, int length, int draw);

        string yearStatistical(DateTime start, DateTime end);

        OrderYear getOrderYearById(long id);
    }
}
