using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using TestClass;
using System.Collections.Generic;
using Task5._3;

namespace Test
{
    [TestClass]
    public class TestClass
    {

        XMLWorker xml = new XMLWorker();

        public string filePath = Data.filePath;
        public XDocument xDoc;

        [TestInitialize()]
        public void Initialize()
        {
            xml.ReadXml(filePath);

        }

        [TestMethod]
        public void TestTotalTurnover()
        {
            int countOfCustomers = xml.CalculationOfTotalTurnoverGreaterThanX(4272).Count;
            xml.customers.RemoveAt(0);
            int countOfCustomers2 = xml.CalculationOfTotalTurnoverGreaterThanX(4272).Count;
            Assert.AreEqual(countOfCustomers - countOfCustomers2, 1);

        }

        [TestMethod]
        public void TestGroupCustomerByCountry()
        {
            int countOfCustomers = xml.GroupCustomersByCountry()["Mexico"].Count;
            xml.customers.RemoveAt(1);
            int countOfCustomers2 = xml.GroupCustomersByCountry()["Mexico"].Count;
            Assert.AreEqual(countOfCustomers - countOfCustomers2, 1);
        }

        [TestMethod]
        public void TestCustomersThatHaveTotalTurnoverGreaterThanX()
        {
            int countOfCustomers = xml.SearchCustomersThatHaveTotalTurnoverGreaterThanX(814).Count;
            xml.customers.RemoveAt(0);
            int countOfCustomers2 = xml.SearchCustomersThatHaveTotalTurnoverGreaterThanX(814).Count;
            Assert.AreEqual(countOfCustomers - countOfCustomers2, 1);

        }


        [TestMethod]
        public void TestCustomersDateFirstOrder()
        {
            List<string> listOfCustomers = xml.CalculateWhenCustomersHadFirstOrder();
            Assert.AreEqual(listOfCustomers[0], "1997-08-25T00:00:00");

        }

        //[TestMethod]
        //public void TestSortCustomerByDateNameAndSum()
        //{
        //    List<List<XElement>> listOfCustomers = xml.SortFirstOrderByYearAndMonthAndTotalTurnoverAndName();
        //    Assert.AreEqual(listOfCustomers[0], "1997-08-25T00:00:00");

        //}


        [TestMethod]
        public void TestCustomersWithIncorrectInformation()
        {
            int countOfCustomers = xml.CalculateCustomersWithIncorrectInformation().Count;
            xml.customers.RemoveAt(0);
            int countOfCustomers2 = xml.CalculateCustomersWithIncorrectInformation().Count;
            Assert.AreEqual(countOfCustomers - countOfCustomers2, 1);

        }


        [TestMethod]
        public void TestAverageCityIncome()
        {
            Decimal avProfit = xml.CalculateAverageCityIncome()["Berlin"];
            decimal.Round(avProfit, 2);
            Assert.AreEqual(712.17M, decimal.Round(avProfit, 2));
        }

        [TestMethod]
        public void TestAverageIntensity()
        {
            Decimal avProfit = xml.CalculateAverageCityIncome()["Berlin"];
            Assert.AreEqual(712.17M, decimal.Round(avProfit, 2));
        }

        [TestMethod]
        public void TestAverageClientActivityStatisticsByMonth()
        {
            int countMonth = xml.CalculationOfAverageClientActivityStatisticsByMonth().Count;
            Assert.AreEqual(countMonth, 12);
        }

        [TestMethod]
        public void TestAverageClientActivityStatisticsByYear()
        {
            int countYear = xml.CalculationOfAverageClientActivityStatisticsByYear().Count;
            Assert.AreEqual(countYear, 3);
        }

        [TestMethod]
        public void TestAverageClientActivityStatisticsByYearAndMonth()
        {
            int countYear = xml.CalculationOfAverageClientActivityStatisticsByMonthAndYear().Count;
            Assert.AreEqual(countYear, 23);
        }


    }
}
