using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Linq.Expressions;

namespace Task5._2
{
    class Calculator
    {
        Fibonnachi fib = new Fibonnachi();
        List<BigInteger> fibNumber;

        public Calculator()
        {
            fibNumber = fib.CalculationFibonnachiNumbers();
        }

        public void Res()
        {
            Console.WriteLine("Count of fib numbers =" + fibNumber.Count);

            IEnumerable<BigInteger> res = fibNumber.Where(i=> i.isEasyNumber());
            Console.WriteLine("Count of easy numbers =" + res.ToList().Count);

            var newDel5 = fibNumber.Where(i => (i % 5 == 0)).ToList().Count;
            Console.WriteLine("Count of numbers that devision on five ="+ newDel5);


          

        }


        public void ResultEasyNumber()
        {
            int count = 0;
            for (int i = 0; i < fibNumber.Count; i++)
            {
               // Console.WriteLine("fibNumber: " + fibNumber[i]);
                if (fibNumber[i].isEasyNumber())
                {
                    count++;
                }
            }
          }

        public void NumeralInNumber()
        {
            List<BigInteger> res = fibNumber.Where(i => i % i.GetCountNumeralInNumber() == 0).ToList();
            Console.WriteLine("Count of numbers that devision on sum numeral =" + res.Count);
        }

        //public  void GetCountNumberDevTwo()
        //{
        //    //int count = 0;
        //   // int i = 0;
        //    foreach(int i in fibNumber)
        //    {
        //        i = 0;
        //        if (fibNumber.Contains(2))
        //        {
        //            i = i ^ (1 / 2);
        //            Console.WriteLine("qqq = "+i);
        //        } 
        //    }
        //}

    }
}
