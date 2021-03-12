using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myprint.Entity;

namespace myprint.dal
{
    public interface PrintOrderDAL
    {
        
        int count();

        List<PrintOrder> page(int start, int length);

        PrintOrder getPrintOrder(long id);

        bool addPrintOrder(PrintOrder printOrder);

        bool deteleById(long id);

        bool updateStatusById(long id);

        int sumPrintNumber(DateTime start, DateTime end);

        double sumAmount(DateTime start, DateTime end);
    }
}
