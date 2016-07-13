using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task5._3
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int x = Int32.Parse(Data.x);
        string filePath = Data.filePath;
        XMLWorker xml = new XMLWorker();
           xml.ReadXml(filePath);
            //  xml.ShowCostomers();
            //   xml.Task2();
            //   xml.Task3(x);
            xml.SortFirstOrderByYearAndMonthAndTotalTurnoverAndName();
            //    xml.Task5();
            //   xml.SerchCustomerWithoutNormalCoseOrRegionOrNormalPhone();
            //    xml.CalculateCustomersWithIncorrectInformation();
            //  xml.Task7();
            // xml.Task8();

            Console.ReadLine();
        }
    }
}
