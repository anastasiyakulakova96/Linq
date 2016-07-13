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
        Fibonnachi fibonnachi = new Fibonnachi();
        List<BigInteger> numbers;

        public Calculator()
        {
            numbers = fibonnachi.CalculationFibonnachiNumbers();
        }

        public int CalculateCountOfEasyNumber()
        {
            return numbers.Where(i => i.IsEasyNumber()).Count();
        }

        public void ShowCountOfEasyNumbers()
        {
            var countOfeasyNumber = CalculateCountOfEasyNumber();
            Console.WriteLine($"Count of easy numbers = {countOfeasyNumber}\n");
        }

        public int CalculateCountOfNumbersThatAreDivisibleByTheSumOwnNumeral()
        {
            return numbers.Where(i => (i % (DigitsInNumber(i).Sum()) == 0)).Count();
        }

        public void ShowCountOfNumbersThatAreDivisibleByTheSumOwnNumeral()
        {
            var countOfNumberThatDivisionOnSumNumeral = CalculateCountOfNumbersThatAreDivisibleByTheSumOwnNumeral();
            Console.WriteLine($"Count of numbers that devision on sum own numeral = {countOfNumberThatDivisionOnSumNumeral} \n");
        }

        public int CalculateCountOfNumbersThatDevisionOnFive()
        {
            return numbers.Where(i => (i % 5 == 0)).Count();
        }

        public void ShowCountOfNumbersThatDevisionOnFive()
        {
            var countOfNumbersThatDevisionOnFive = CalculateCountOfNumbersThatDevisionOnFive();
            Console.WriteLine($"Count of numbers that devision on five = {countOfNumbersThatDevisionOnFive}\n");
        }

        public List<BigInteger> SearchNumberTwo()
        {
            return numbers.Where(bi => bi.ToString().IndexOfAny(new char[] { '2' }) != -1).ToList();
        }

        public List<double> CalculateRootOfNumbersThatContainsTwo()
        {
            return SearchNumberTwo().Select(i => Math.Sqrt((double)i)).ToList();
        }

        public void ShowRootsOfNumberThatContainsTwo()
        {
            string result = "";
            var listRoot = CalculateRootOfNumbersThatContainsTwo();
            foreach (BigInteger i in listRoot)
            {
                result += i + " ";
            }
            Console.WriteLine($"Roots of number that contains two: \n{result}\n");
        }

        public IOrderedEnumerable<BigInteger> SortByDecreasingNumberOfSecondNumber()
        {
            return numbers.Where(i => DigitsInNumber(i).Count > 1)
                .OrderByDescending(i => DigitsInNumber(i)
                .ElementAt(1));
        }

        public void ShowSortedByDecreasingNumberOfSecondNumber()
        {
            string result = "";
            var sortedList = SortByDecreasingNumberOfSecondNumber();

            foreach (BigInteger i in sortedList)
            {
                result += i + " ";
            }
            Console.WriteLine($"Sorted by descending number of second number: \n {result}\n");
        }

        public IEnumerable<string> CalculationOfTwoDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive()
        {
            var listOfNumbersThatDivisionByThree = numbers.Where(i => i % 3 == 0).ToList();

            var listOfNumbersThatDivisionByThreeAndNearHaveNumberThatDivisionByFive = listOfNumbersThatDivisionByThree.Where((num, index) =>
            numbers.GetRange(index <= 5 ? 0 : index - 5, index + 5 <= numbers.Count ? index + 5 : numbers.Count)
            .Where(i => i % 5 == 0).ToList().Count > 0).ToList();

            return listOfNumbersThatDivisionByThreeAndNearHaveNumberThatDivisionByFive.Select(i => DigitsInNumber(i).Count < 2 ? i.ToString() : i.ToString().Substring(i.ToString().Length - 2, 2));
        }

        public void ShowDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive()
        {
            string result = "";
            var listOfTwoDigitNumber = CalculationOfTwoDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive();

            foreach (var i in listOfTwoDigitNumber)
            {
                result += i + " ";
            }
            Console.WriteLine($"Digit-number that divisible by three and near have number that divisible by five:\n {result} \n");
        }

        public BigInteger[] CalculateMaxSumOfTheSquaresOfNumbers()
        {
            var squaresOfNumbers = numbers.Select(i => DigitsInNumber(i).Select(x => (x * x))).ToList();
            var sumOfTheSquaresOfNumbers = squaresOfNumbers.Select(i => i.Sum());
            var maxSumAndHerNomber = numbers.Select(i => new
            {
                Number = i,
                Sum = DigitsInNumber(i)
                .Select(x => (x * x)).Sum()
            })
                .Where(i => i.Sum == sumOfTheSquaresOfNumbers.Max()).ToList();

            return new BigInteger[] { maxSumAndHerNomber[0].Number, maxSumAndHerNomber[0].Sum };

        }

        public void ShowMaxSumOfTheSquaresOfNumbers()
        {
            var result = CalculateMaxSumOfTheSquaresOfNumbers();

            Console.WriteLine($"Number that have max sum of squres in numbers: {result[0]}. Him sum of squres in this number: {result[1]}\n");
        }

        public double CalculateAvgerageCountOfZeroInNumbers()
        {
            return numbers.Select(i => DigitsInNumber(i).Where(q => q == 0).Count()).Average();
        }

        public void ShowAvgerageCountOfZeroInNumbers()
        {
            var averageZero = CalculateAvgerageCountOfZeroInNumbers();
            Console.WriteLine($"Average count zero in numbers: {averageZero.ToString("0.00")}");
        }

        public List<int> DigitsInNumber(BigInteger number)
        {
            return number.ToString().ToCharArray().Select(item => (int)Char.GetNumericValue(item)).ToList();
        }

    }
}
