using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.dal.impl;

namespace myprint.BLL.impl
{
     public class OrderMonthBLLImpl : OrderMonthBLL
    {
        public string monthStatistical(DateTime start, DateTime end)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            OrderMonthDALImpl orderMonthDALImpl = new OrderMonthDALImpl();
            int printNumber = printOrderDALImpl.sumPrintNumber(start, end);
            double totalAmount = printOrderDALImpl.sumAmount(start, end);
            orderMonthDALImpl.statistical(printNumber, totalAmount, start, end);
            return "月记录更新";
        }

        public OrderMonth getOrderMonthById(long id)
        {
            OrderMonthDALImpl orderMonthDALImpl = new OrderMonthDALImpl();
            return orderMonthDALImpl.getOrderMonthById(id);
        }

        public PageInfo<OrderMonth> page(int start, int length, int draw)
        {
            OrderMonthDALImpl orderMonthDALImpl = new OrderMonthDALImpl();
            PageInfo<OrderMonth> pageInfo = new PageInfo<OrderMonth>();
            int count = orderMonthDALImpl.count();
            pageInfo.draw = draw;
            pageInfo.recordsTotal = count;
            pageInfo.recordsFiltered = count;
            pageInfo.data = orderMonthDALImpl.page(start, length);
            return pageInfo;
        }
    }
}
