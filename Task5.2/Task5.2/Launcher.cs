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
            ConsoleWorker cw = new ConsoleWorker();

            cw.ShowCountOfPrimeNumbers();
            cw.ShowCountOfNumbersThatAreDivisibleByTheSumOwnNumeral();
            cw.ShowCountOfNumbersThatDevisionOnFive();
            cw.ShowRootsOfNumberThatContainsTwo();
            cw.ShowSortedByDecreasingNumberOfSecondNumber();
            cw.ShowDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive();
            cw.ShowMaxSumOfTheSquaresOfNumbers();
            cw.ShowAvgerageCountOfZeroInNumbers();

            Console.ReadLine();
        }

    }
}
