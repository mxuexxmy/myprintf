using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.dal
{
    public interface OrderMonthDAL
    {
        int count();

        List<OrderMonth> page(int start, int length);

        bool statistical(int printNumbr, double totalAmount, DateTime start, DateTime end);

        OrderMonth getOrderMonthById(long id);
    }
}
