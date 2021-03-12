using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.BLL
{
    public interface OrderDayBLL
    {
        PageInfo<OrderDay> page(int start, int length, int draw);

        string  dayStatistical(DateTime start, DateTime end);

        OrderDay getOrderById(long id);
    }
}
