using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace CowboyBipBoup.Model
{
    public static class XlsxSerializer
    {
        public static ManagerCowboy GetData(string xlsxPath)
        {
            WorkBook excelFile = WorkBook.Load(xlsxPath);
            //examples
            WorkSheet workSheet = excelFile.WorkSheets[0];
            string cellValue = workSheet["A2"].StringValue;
            //


            var manager = new ManagerCowboy();
            return manager;
        }
    }
}
