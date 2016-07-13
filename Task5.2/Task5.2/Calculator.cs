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

        public int CalculateCountOfPrimeNumber()
        {
            return numbers.Where(i => i.IsPrimeNumber()).Count();
        }

        public int CalculateCountOfNumbersThatAreDivisibleByTheSumOwnNumeral()
        {
            return numbers.Where(i => (i % (DigitsInNumber(i).Sum()) == 0)).Count();
        }

        public int CalculateCountOfNumbersThatDevisionOnFive()
        {
            return numbers.Where(i => (i % 5 == 0)).Count();
        }

        public List<BigInteger> SearchNumberTwo()
        {
            return numbers.Where(bi => bi.ToString().IndexOfAny(new char[] { '2' }) != -1).ToList();
        }

        public List<double> CalculateRootOfNumbersThatContainsTwo()
        {
            return SearchNumberTwo().Select(i => Math.Sqrt((double)i)).ToList();
        }

        public IOrderedEnumerable<BigInteger> SortByDecreasingNumberOfSecondNumber()
        {
            return numbers.Where(i => DigitsInNumber(i).Count > 1)
                .OrderByDescending(i => DigitsInNumber(i)
                .ElementAt(1));
        }

        public IEnumerable<string> CalculationOfTwoDigitNumberThatDivisibleByThreeAndNearHaveNumberThatDivisibleByFive()
        {
            var listOfNumbersThatDivisionByThree = numbers.Where(i => i % 3 == 0).ToList();

            var listOfNumbersThatDivisionByThreeAndNearHaveNumberThatDivisionByFive = listOfNumbersThatDivisionByThree.Where((num, index) =>
            numbers.GetRange(index <= 5 ? 0 : index - 5, index + 5 <= numbers.Count ? index + 5 : numbers.Count)
            .Where(i => i % 5 == 0).ToList().Count > 0).ToList();

            return listOfNumbersThatDivisionByThreeAndNearHaveNumberThatDivisionByFive.Select(i => DigitsInNumber(i).Count < 2 ? i.ToString() : i.ToString().Substring(i.ToString().Length - 2, 2));
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

        public double CalculateAvgerageCountOfZeroInNumbers()
        {
            return numbers.Select(i => DigitsInNumber(i).Where(q => q == 0).Count()).Average();
        }

        public List<int> DigitsInNumber(BigInteger number)
        {
            return number.ToString().ToCharArray().Select(item => (int)Char.GetNumericValue(item)).ToList();
        }
    }
}
