using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.dal.impl;

namespace myprint.BLL.impl
{
    public class OrderYearBLLImpl : OrderYearBLL
    {
        public PageInfo<OrderYear> page(int start, int length, int draw)
        {
            OrderYearDALImpl orderYearDALImpl = new OrderYearDALImpl();
            PageInfo<OrderYear> pageInfo = new PageInfo<OrderYear>();
            int count = orderYearDALImpl.count();
            pageInfo.draw = draw;
            pageInfo.recordsTotal = count;
            pageInfo.recordsFiltered = count;
            pageInfo.data = orderYearDALImpl.page(start, length);
            return pageInfo;
        }

        public string yearStatistical(DateTime start, DateTime end)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            OrderYearDALImpl orderYearDALImpl = new OrderYearDALImpl();
            int printNumber = printOrderDALImpl.sumPrintNumber(start, end);
            double totalAmount = printOrderDALImpl.sumAmount(start, end);
            orderYearDALImpl.statistical(printNumber, totalAmount, start, end);
            return "年记录更新";
        }

        public OrderYear getOrderYearById(long id)
        {
            OrderYearDALImpl orderYearDALImpl = new OrderYearDALImpl();
            return orderYearDALImpl.getOrderYearById(id);
        }
    }
}
