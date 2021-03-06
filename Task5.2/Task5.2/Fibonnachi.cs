﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task5._2
{
    class Fibonnachi
    {
        int countOfFibonnachiNumbers = Int32.Parse(Data.countOfFibonnachiNumbers);

        public List<BigInteger> CalculationFibonnachiNumbers()
        {
            List<BigInteger> listFibonnachiNumbers = new List<BigInteger>();
            BigInteger j = 1;
            int k = 0;
            Console.WriteLine($"{countOfFibonnachiNumbers} numbers of Fibonnachi:");
            for (BigInteger i = 1; ; i += j)
            {
                if (k == countOfFibonnachiNumbers)
                {
                    break;
                }
                Console.Write("{0} ", i);
                listFibonnachiNumbers.Add(i);
                j = i - j;
                k++;
            }
            Console.WriteLine("\n");
            return listFibonnachiNumbers;
        }
    }
}
