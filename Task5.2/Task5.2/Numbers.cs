using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    public static class CalculatorEasyNumbers
    {
        //public static bool CheckNumber(BigInteger current)
        //{
        //    bool result = true;
        //    if (current > 2) return result;
        //    for (int i = 2; i < current; i++)
        //    {
        //        if (current % i == 0)
        //        {
        //            result = false;
        //            break;
        //        }
        //    }
        //    return result;
        //}


        public static bool EasyNumber(BigInteger n)
        {
            if (n == 1)
                return false;
            for (int d = 2; d * d <= n; d++)
            {
                if (n % d == 0)
                    return false;
            }
            return true;
        }


        public static bool q(BigInteger source)
        {
            int certainty = 10;
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {

                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }

        public static bool IsEasyNumber(this BigInteger number)
        {
            return q(number);
        }
    }

        

        //public static int GetCountNumeralInNumber(this BigInteger number)
        //{
        //    int count = 0;
        //    while (number != 0)
        //    {
        //        number /= 10;
        //        count++;
        //    }
        //    return count;
        //}


    }

