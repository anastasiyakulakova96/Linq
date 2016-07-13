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
           // Launcher launcher = new Launcher();
            Calculator calc = new Calculator();

            calc.ShowCountOfEasyNumbers();
            calc.ShowCountOfNumbersThatAreDivisibleByTheSumOwnNumeral();
            calc.ShowCountOfNumbersThatDevisionOnFive();
            calc.ShowRootsOfNumberThatContainsTwo();
            calc.ShowSortedByDecreasingNumberOfSecondNumber();
            calc.ShowDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive();
            calc.ShowMaxSumOfTheSquaresOfNumbers();
            calc.ShowAvgerageCountOfZeroInNumbers();

            Console.ReadLine();
        }
    }
}
