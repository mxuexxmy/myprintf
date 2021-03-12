using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myprint.dal.impl
{
    public class OrderYearDALImpl : OrderYearDAL
    {
        public int count()
        {
            using (var db = new PrintingEntities())
            {
                var count = db.tb_order_year.Count();
                return count;
            }
        }

        public OrderYear getOrderYearById(long id)
        {
            using (var db = new PrintingEntities())
            {
                OrderYear orderYear = db.tb_order_year.Where(u => u.id == id).FirstOrDefault();
                return orderYear;
            }
        }

        public List<OrderYear> page(int start, int length)
        {
            using (var db = new PrintingEntities())
            {
                int startRow = (start) * length;
                List<OrderYear> orderYears = db.tb_order_year.OrderByDescending(p => p.create_time).Skip(startRow).Take(length).ToList<OrderYear>();
                return orderYears;
            }
        }

        public bool statistical(int printNumbr, double totalAmount, DateTime start, DateTime end)
        {
            using (var db = new PrintingEntities())
            {

                OrderYear orderYear = db.tb_order_year.FirstOrDefault(u => u.stats_year == start);
                if (orderYear == null)
                {
                    TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
                    long t = (long)cha.TotalSeconds;
                    OrderYear _orderYear = new OrderYear();
                    _orderYear.id = t;
                    _orderYear.stats_year = start;
                    _orderYear.print_number = printNumbr;
                    _orderYear.total_amount = totalAmount;
                    _orderYear.create_time = DateTime.Now;
                    _orderYear.update_time = DateTime.Now;
                    db.tb_order_year.Add(_orderYear);
                }
                else
                {
                    orderYear.print_number = printNumbr;
                    orderYear.total_amount = totalAmount;
                    orderYear.update_time = DateTime.Now;
                }
                db.SaveChanges();
                return true;
            }
        }
    }
}
