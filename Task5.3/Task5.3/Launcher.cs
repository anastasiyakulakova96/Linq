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
            XMLWorker xml = new XMLWorker();
            xml.ReadXml();
            //  xml.ShowCostomers();
            //   xml.Task2();
            //   xml.Task3(x);
            //  xml.Task4();
            xml.Task5();



            Console.ReadLine();
        }
    }
}
