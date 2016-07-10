using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    public static class CalculatorEasyNumbers
    {
        public static bool CheckNumber(BigInteger current)
        {
            bool result = true;
            if (current == 2) return result;
            for (int i = 2; i < current; i++)
            {
                if (current % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool isEasyNumber(this BigInteger number)
        {
            return CheckNumber(number);
        }

        public static int GetCountNumeralInNumber(this BigInteger number)
        {
            int count = 0;
            while(number != 0)
            {
                number /= 10;
                count++;
            }
            return count;
        }

        
    }
}
