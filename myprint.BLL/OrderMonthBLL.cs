using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.BLL
{
    public interface OrderMonthBLL
    {
        PageInfo<OrderMonth> page(int start, int length, int draw);
        string monthStatistical(DateTime start, DateTime end);
        OrderMonth getOrderMonthById(long id);

    }
}
