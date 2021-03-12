using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.BLL
{
    public interface PrintOrderBLL
    {
        PageInfo<PrintOrder> page(int start, int length, int draw);

        PrintOrder getPrintOrder(long id);

        string addPrintOrder(PrintOrder printOrder);

        bool deleteById(long id);

        string updateStatusByid(long id);
    }
}
