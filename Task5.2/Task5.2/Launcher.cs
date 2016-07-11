using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    class Launcher
    {
       

      

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            Calculator calc = new Calculator();
           // calc.ResultEasyNumber();
            calc.Res();
            calc.Sqrt();
            calc.NumeralInNumber();
            calc.Sort();
            calc.SumSqrtNumbers();
            calc.CountOfZero();
            calc.number6();
          //  calc.GetCountNumberDevTwo();

            Console.ReadLine();
        }

    }
}
