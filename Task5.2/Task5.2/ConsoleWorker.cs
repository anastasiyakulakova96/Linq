using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    class ConsoleWorker
    {
        Calculator calc = new Calculator();

        public void ShowCountOfPrimeNumbers()
        {
            var countOfeasyNumber = calc.CalculateCountOfPrimeNumber();
            Console.WriteLine($"Count of prime numbers = {countOfeasyNumber}\n");
        }

        public void ShowCountOfNumbersThatAreDivisibleByTheSumOwnNumeral()
        {
            var countOfNumberThatDivisionOnSumNumeral = calc.CalculateCountOfNumbersThatAreDivisibleByTheSumOwnNumeral();
            Console.WriteLine($"Count of numbers that devision on sum own numeral = {countOfNumberThatDivisionOnSumNumeral} \n");
        }

        public void ShowCountOfNumbersThatDevisionOnFive()
        {
            var countOfNumbersThatDevisionOnFive = calc.CalculateCountOfNumbersThatDevisionOnFive();
            Console.WriteLine($"Count of numbers that devision on five = {countOfNumbersThatDevisionOnFive}\n");
        }

        public void ShowRootsOfNumberThatContainsTwo()
        {
            string result = "";
            var listRoot = calc.CalculateRootOfNumbersThatContainsTwo();
            foreach (BigInteger i in listRoot)
            {
                result += i + " ";
            }
            Console.WriteLine($"Roots of number that contains two: \n{result}\n");
        }

        public void ShowSortedByDecreasingNumberOfSecondNumber()
        {
            string result = "";
            var sortedList = calc.SortByDecreasingNumberOfSecondNumber();

            foreach (BigInteger i in sortedList)
            {
                result += i + " ";
            }
            Console.WriteLine($"Sorted by descending number of second number: \n {result}\n");
        }

        public void ShowDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive()
        {
            string result = "";
            var listOfTwoDigitNumber = calc.CalculationOfTwoDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive();

            foreach (var i in listOfTwoDigitNumber)
            {
                result += i + " ";
            }
            Console.WriteLine($"Digit-number that divisible by three and near have number that divisible by five:\n {result} \n");
        }

        public void ShowMaxSumOfTheSquaresOfNumbers()
        {
            var result = calc.CalculateMaxSumOfTheSquaresOfNumbers();

            Console.WriteLine($"Number that have max sum of squres in numbers: {result[0]}. Him sum of squres in this number: {result[1]}\n");
        }

        public void ShowAvgerageCountOfZeroInNumbers()
        {
            var averageZero = calc.CalculateAvgerageCountOfZeroInNumbers();
            Console.WriteLine($"Average count zero in numbers: {averageZero.ToString("0.00")}");
        }
    }
}
