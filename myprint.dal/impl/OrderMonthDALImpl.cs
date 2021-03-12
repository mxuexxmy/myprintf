using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myprint.dal.impl
{
    public class OrderMonthDALImpl : OrderMonthDAL
    {
        public int count()
        {
            using (var db = new PrintingEntities())
            {
                var count = db.tb_order_month.Count();
                return count;
            }
        }

        public OrderMonth getOrderMonthById(long id)
        {
            using (var db = new PrintingEntities())
            {
                OrderMonth orderMonth = db.tb_order_month.Where(u => u.id == id).FirstOrDefault();
                return orderMonth;
            }
        }

        public List<OrderMonth> page(int start, int length)
        {
            using (var db = new PrintingEntities())
            {
                int startRow = (start) * length;
                List<OrderMonth> orderMonths = db.tb_order_month.OrderByDescending(p => p.create_time).Skip(startRow).Take(length).ToList<OrderMonth>();
                return orderMonths;
            }
        }

        public bool statistical(int printNumbr, double totalAmount, DateTime start, DateTime end)
        {

            using (var db = new PrintingEntities())
            {

                OrderMonth orderMonth = db.tb_order_month.FirstOrDefault(u => u.stats_month == start);
                if (orderMonth == null)
                {
                    TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
                    long t = (long)cha.TotalSeconds;
                    OrderMonth _orderMonth = new OrderMonth();
                    _orderMonth.id = t;
                    _orderMonth.stats_month = start;
                    _orderMonth.print_number = printNumbr;
                    _orderMonth.total_amount = totalAmount;
                    _orderMonth.create_time = DateTime.Now;
                    _orderMonth.update_time = DateTime.Now;
                    db.tb_order_month.Add(_orderMonth);
                }
                else
                {
                    orderMonth.print_number = printNumbr;
                    orderMonth.total_amount = totalAmount;
                    orderMonth.update_time = DateTime.Now;
                }
                db.SaveChanges();
                return true;
            }
        }
    }
}
