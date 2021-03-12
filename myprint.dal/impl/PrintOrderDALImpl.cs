using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
namespace myprint.dal.impl
{
    public class PrintOrderDALImpl : PrintOrderDAL
    {
        public bool addPrintOrder(PrintOrder printOrder)
        {
            using (var db = new PrintingEntities())
            {
                db.tb_print_order.Add(printOrder);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 统计打印订单数量
        /// </summary>
        /// <returns></returns>
        public int count()
        {

            using (var db = new PrintingEntities())
            {
                var count = db.tb_print_order.Count();
                return count;
            }
        }

        public bool deteleById(long id)
        {
            using (var db = new PrintingEntities())
            {
                PrintOrder printOrder = new PrintOrder() { id = id};
                db.tb_print_order.Attach(printOrder);
                db.tb_print_order.Remove(printOrder);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public PrintOrder getPrintOrder(long id)
        {
            using (var db = new PrintingEntities())
            {
                var printOrder = db.tb_print_order.FirstOrDefault(b => b.id == id);
                return printOrder;
            }
        }

        /// <summary>
        /// 打印订单分页
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<PrintOrder> page(int start, int length)
        {
            using (var db = new PrintingEntities())
            {
                List<PrintOrder> printOrders = db.tb_print_order.OrderByDescending(p => p.create_time).Skip(start).Take(length).ToList<PrintOrder>();
                return printOrders;
            }
        }

        public double sumAmount(DateTime start, DateTime end)
        {
            using (var db = new PrintingEntities())
            {
                 //double totalamount = db.tb_print_order.Where(u => u.create_time == start && u.create_time == end).Sum(u => u.total_amount).Value;
                 double totalamount = (double) db.tb_print_order.Where(u => u.create_time > start &&  u.create_time < end).Sum(u => u.total_amount);
                return totalamount;
            }
        }

        public int sumPrintNumber(DateTime start, DateTime end)
        {
            using (var db = new PrintingEntities())
            {
                // int printNumber = db.tb_print_order.Where(u => u.create_time == start && u.create_time == end).Sum(u => u.prinf_number).Value;

                int printNumber = (int) db.tb_print_order.Where(u => u.create_time > start && u.create_time < end ).Sum(u => u.prinf_number);

                return printNumber;
            }
        }

        public bool updateStatusById(long id)
        {
            using (var db = new PrintingEntities())
            {
                // 先查询出订单
                PrintOrder printOrder = db.tb_print_order.Where(u => u.id == id).FirstOrDefault();
                printOrder.order_status = "是";
                int count =  db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
