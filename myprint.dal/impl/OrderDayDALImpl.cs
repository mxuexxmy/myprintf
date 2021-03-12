using myprint.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myprint.dal.impl
{
    public class OrderDayDALImpl : OrderDayDAL
    {
        public int count()
        {
            using (var db = new PrintingEntities())
            {
                var count = db.tb_order_day.Count();
                return count;
            }
        }

        public OrderDay getOrderById(long id)
        {
            using (var db = new PrintingEntities())
            {
                var orderDay = db.tb_order_day.Where(u => u.id == id).FirstOrDefault();
                return orderDay;
            }
        }

        public List<OrderDay> page(int start, int length)
        {
            using (var db = new PrintingEntities())
            {
                int startRow = (start) * length;
                List<OrderDay> orderDays = db.tb_order_day.OrderByDescending(p => p.create_time).Skip(startRow).Take(length).ToList<OrderDay>();
                return orderDays;
            }
        }

        public bool statistical(int printNumbr, double totalAmount, DateTime start, DateTime end)
        {
            using (var db = new PrintingEntities())
            {

                OrderDay orderDay = db.tb_order_day.FirstOrDefault(u => u.stats_day == start);
                if (orderDay == null)
                {
                    TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
                    long t = (long)cha.TotalSeconds;
                    OrderDay _orderDay = new OrderDay();
                    _orderDay.id = t;
                    _orderDay.stats_day = start;
                    _orderDay.print_number = printNumbr;
                    _orderDay.total_amount = totalAmount;
                    _orderDay.create_time = DateTime.Now;
                    _orderDay.update_time = DateTime.Now;
                    db.tb_order_day.Add(_orderDay);
                } else
                {
                    orderDay.print_number = printNumbr;
                    orderDay.total_amount = totalAmount;
                    orderDay.update_time = DateTime.Now;
                }
                db.SaveChanges();
                return true;
            }
        }
    }
}
