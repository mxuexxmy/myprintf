using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.dal
{
    public interface OrderYearDAL
    {
        int count();

        List<OrderYear> page(int start, int length);

        bool statistical(int printNumbr, double totalAmount, DateTime start, DateTime end);

        OrderYear getOrderYearById(long id);
    }
}
