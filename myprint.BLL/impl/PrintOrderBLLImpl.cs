using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.dal.impl;

namespace myprint.BLL.impl
{
    public class PrintOrderBLLImpl : PrintOrderBLL
    {
        public string addPrintOrder(PrintOrder printOrder)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();

            if (printOrder.user_name == null)
            {
                return  "请输入姓名！";
            }

            if (printOrder.prinf_number == null)
            {
                return "请输入打印份数！";
               
            }

            if (printOrder.paper_number == null)
            {
                return "请输入打印张数！";
            }

            if (printOrder.amount == null)
            {
                return "请输入一张的价格！";
            }

            TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long t = (long)cha.TotalSeconds;
            printOrder.id = t;
            printOrder.total_amount = printOrder.prinf_number * printOrder.paper_number * printOrder.amount;
            printOrder.order_status = "否";
            printOrder.create_time = DateTime.Now;
            printOrder.update_time = DateTime.Now;

            bool b = printOrderDALImpl.addPrintOrder(printOrder);

            if (b)
            {
                return "添加打印记录成功，共" + printOrder.total_amount + "元。";
            }

            return "添加打印记录失败！";

        }

        public bool deleteById(long id)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            return printOrderDALImpl.deteleById(id);
        }

        public PrintOrder getPrintOrder(long id)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            PrintOrder printOrder = printOrderDALImpl.getPrintOrder(id);
            return printOrder;
        }

        public PageInfo<PrintOrder> page(int start, int length, int draw)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            PageInfo<PrintOrder> pageInfo = new PageInfo<PrintOrder>();
            int count = printOrderDALImpl.count();
            pageInfo.draw = draw;
            pageInfo.recordsTotal = count;
            pageInfo.recordsFiltered = count;
            pageInfo.data = printOrderDALImpl.page(start, length);

            return pageInfo;
        }

        public string updateStatusByid(long id)
        {
            PrintOrderDALImpl printOrderDALImpl = new PrintOrderDALImpl();
            bool b = printOrderDALImpl.updateStatusById(id);
            if (b)
            {
                return "序号" + id + "的订单已完成！";
            }
            return "序号" + id + "的订单已确认，请勿重新确认！";
        }
    }
}
