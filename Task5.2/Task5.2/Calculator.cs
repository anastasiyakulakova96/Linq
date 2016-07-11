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
      //  List<int> numbers;
        public Calculator()
        {
            fibNumber = fib.CalculationFibonnachiNumbers();
            Console.WriteLine("Count of fib numbers =" + fibNumber.Count);
        }

        public void Res()
        {
           
            IEnumerable<BigInteger> res = fibNumber.Where(i=> i.IsEasyNumber()).ToList();
            Console.WriteLine("Count of easy numbers =" + res.Count());

            var newDel5 = fibNumber.Where(i => (i % 5 == 0)).ToList().Count;
            Console.WriteLine("Count of numbers that devision on five ="+ newDel5);


         //   var a = fibNumber.Select(i => (DigitsInNumber(i).Where(q=>q==2).Count()!=0));

            //    var b = a.Where(i =>(i.Where(q=>q.Equals(2))));
          //  var b = a.Where(i => (i == 2));
            //  var b= from x in fibNumber(from i in (DigitsInNumber(i)))
            Console.WriteLine("");

        }


        public void NumeralInNumber()
        {
            var numberThatDivisionOnSumNumeral = fibNumber.Where(i => (i % (DigitsInNumber(i).Sum()) == 0)).Count();

            Console.WriteLine("Count of numbers that devision on sum numeral =" + numberThatDivisionOnSumNumeral);
        }


        public List<BigInteger> SearchNumberTwo()
        {
          return fibNumber.Where(bi => bi.ToString().IndexOfAny(new char[] { '2' }) != -1).ToList();
        }


          public void Sqrt()
        {
            string result = "";
            var a = SearchNumberTwo().Select(i => Math.Sqrt((double)i)).ToList();

            foreach (BigInteger i in a)
            {
                result += i+" ";
            }
            Console.WriteLine("Sqrt number that contains two =" + result);
            
        }

        public void Sort()
        {
            string result = "";
          
            var  sotrList = fibNumber.Where(i=>DigitsInNumber(i).Count>1).OrderByDescending(i=>DigitsInNumber(i).ElementAt(1));
     
            foreach (BigInteger i in sotrList)
            {
                result += i + " ";
            }
            Console.WriteLine("Sotr numbers  ="+ result);
        }


        public void SumSqrtNumbers()
        {

           var sqrtNumber = fibNumber.Select(i => DigitsInNumber(i).Select(x=>(x*x))).ToList();
            var sum = sqrtNumber.Select(i => i.Sum());
            var max = sum.Max();
            Console.WriteLine("max ="+max);
        }


        public void CountOfZero()
        {
         var averageZero = fibNumber.Select(i => DigitsInNumber(i).Where(q=> q == 0).Count()).Average();

            Console.WriteLine("avg count ziro =" + averageZero.ToString("0.00"));
        }



        public void number6()
        {
            var a = fibNumber.Where(i =>( i % 3 == 0));


            foreach (int i in fibNumber)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("del na 3 " +i);
                    for(int n=0;n>i+5;n++)
                    {
                        Console.WriteLine("n"+n);
                        if (n % 5 == 0)
                        {
                            Console.WriteLine("i"+ i);
                        }
                    }
                }
            }
        }



        public List<int> DigitsInNumber(BigInteger number)
        {
            return number.ToString().ToCharArray().Select(item => (int)Char.GetNumericValue(item)).ToList();
        }

       }
}
