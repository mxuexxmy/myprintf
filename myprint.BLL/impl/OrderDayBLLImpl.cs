using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.dal.impl;

namespace myprint.BLL.impl
{
    public class OrderDayBLLImpl : OrderDayBLL
    {
        public string dayStatistical(DateTime start, DateTime end)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            OrderDayDALImpl orderDayDALImpl = new OrderDayDALImpl();
            int printNumber = printOrderDALImpl.sumPrintNumber(start, end);
            double totalAmount = printOrderDALImpl.sumAmount(start, end);
            orderDayDALImpl.statistical(printNumber, totalAmount, start, end);
            return "日记录更新";
        }

        public OrderDay getOrderById(long id)
        {
            OrderDayDALImpl orderDayDALImpl = new OrderDayDALImpl();
             return orderDayDALImpl.getOrderById(id);
        }

        public PageInfo<OrderDay> page(int start, int length, int draw)
        {
            OrderDayDALImpl orderDayDALImpl = new OrderDayDALImpl();
            PageInfo<OrderDay> pageInfo = new PageInfo<OrderDay>();
            int count = orderDayDALImpl.count();
            pageInfo.draw = draw;
            pageInfo.recordsTotal = count;
            pageInfo.recordsFiltered = count;
            pageInfo.data = orderDayDALImpl.page(start, length);
            return pageInfo;
        }
    }
}
