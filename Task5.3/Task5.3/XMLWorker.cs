using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task5._3
{
    public class XMLWorker
    {
        public string filePath  = Data.filePath;
        public XDocument xDoc;
      public  List<XElement> customers { get; set; }
        int x = Int32.Parse(Data.x);
        Regex onlyLetters = new Regex(@"(?i)^[a-z]+");
        Regex regex = new Regex(@"\([0-9]\)");
        Regex scopes = new Regex(@"^\(\d+\)");
        public const string POSTALCODE = "postalcode";
        public const string COUNTRY = "country";
        public const string PHONE = "phone";

        public List<XElement> listOrders;

        public void ReadXml(string filePath)
        {
            xDoc = XDocument.Load(filePath);
            customers = xDoc.Root.Elements().ToList();
        }

        //1.	Выдайте список всех клиентов, чей суммарный оборот 
        //(сумма всех заказов) превосходит некоторую величину X. 
        //    Продемонстрируйте выполнение запроса с различными X 
        //    (подумайте, можно ли обойтись без копирования запроса несколько раз)
        public List<XElement> CalculationOfTotalTurnoverGreaterThanX(int x)
        {
            return customers.Where(c => c.Element("orders").Elements("order")
                        .Sum(order => Double.Parse(order.Element("total").Value)) > x).ToList();
        }


        //public void ShowCostomers()
        //{
        //    IEnumerable<XElement> a = Task1(x);
        //    var id = a.Select(i => i.Element("id"));

        //    foreach (var s in id)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}


        //2.	Сгруппировать клиентов по странам.
        public Dictionary<string, List<XElement>> GroupCustomersByCountry()
        {
            return customers.GroupBy(c => c.Element("country").Value).ToDictionary(c => c.Key, c => c.ToList());

            //foreach (var s in a)
            //{

            //    Console.WriteLine(s);
            //}
        }

        //3.	Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X
        public List<XElement> SearchCustomersThatHaveTotalTurnoverGreaterThanX(int x)
        {
            return customers.Where(c => c.Element("orders").Elements("order").Any(order => Double.Parse(order.Element("total").Value) > x)).ToList();

            //foreach (var s in b)
            //{
            //    Console.WriteLine(s);
            //}

        }

        //4.	Выдайте список клиентов с указанием,
        //начиная с какого месяца какого года они стали клиентами (принять за таковые месяц и год самого первого заказа)
        //
        public List<string> CalculateWhenCustomersHadFirstOrder()
        {
            return customers.Select(c => c.Element("orders").Elements("order").FirstOrDefault()?.Element("orderdate").Value).ToList();
            //foreach (var s in a)
            //{
            //    Console.WriteLine(s);
            //}
        }


        // 5.	Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу,
        //оборотам клиента(от максимального к минимальному) и имени клиента

        public List<List<XElement>> SortFirstOrderByYearAndMonthAndTotalTurnoverAndName()
        {
            return customers.Select(c => new
            {
                c = customers,
                data = Convert.ToDateTime(c.Element("orders").Elements("order").FirstOrDefault()?.Element("orderdate").Value),
                sum = c.Element("orders").Elements("order").Sum(order => Double.Parse(order.Element("total").Value)),
                name = c.Element("name").Value
            })
                   .OrderBy(d => d.data.Year).
                    ThenBy(d => d.data.Month).
                      ThenByDescending(s => s.sum).
                       ThenBy(n => n.name).
                       Select(x => x.c).ToList();


            //foreach (var s in a)
            //{
            //    Console.WriteLine(s);
            //}

        }
        //6.	Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора 
        //(для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).
        //public List<XElement> SerchCustomerWithoutNormalCoseOrRegionOrNormalPhone()
        //{
        public List<XElement> CalculateCustomersWithIncorrectInformation()
        {
            int s;
      var a= customers.Where(c => Int32.TryParse(c.Element("postalcode")?.Value.ToString(), out s) == false || c.Element("region")?.Value == null || c.Element("phone")?.Value.Contains("(") == false).ToList();

            foreach (var it in a)
            {
                Console.WriteLine(it.Element("name").Value);

            }
            return a;
        }

        //  7.	Рассчитайте среднюю прибыльность каждого города
        //(среднюю сумму заказа по всем клиентам из данного города) и 
        //среднюю интенсивность(среднее количество заказов, приходящееся на клиента из каждого города)
        public Dictionary<string, decimal> CalculateAverageCityIncome()
        {
            return customers.GroupBy(i => i.Element("city").Value).ToDictionary(g => g.Key,
     g => g.Sum(i => i.Element("orders").Elements("order")
     .Sum(order => Decimal.Parse(order.Element("total").Value))) / g.Sum(q => q.Element("orders").Elements("order").Count()));
        }

        public Dictionary<XElement, int> CalculateAverageIntensity()
        {
            return customers.GroupBy(i => i.Element("city")).ToDictionary(g => g.Key,
  g => g.Sum(i => i.Element("orders").Elements("order").Count()) / g.Count());
        }


        //8.	Сделайте среднегодовую статистику активности клиентов по месяцам (без учета года), 
        //статистику по годам, по годам и месяцам (т.е. когда один месяц в разные годы имеет своё значение).



        public void AddAllOrders()
        {
            listOrders = new List<XElement>();

            foreach (var item in customers)
            {
                listOrders.AddRange(item.Element("orders").Elements("order"));
            }
        }



        public List<IGrouping<int, XElement>> CalculationOfAverageClientActivityStatisticsByMonth()
        {
            AddAllOrders();

            return listOrders.GroupBy(d => Convert.ToDateTime(d.Element("orderdate").Value).Month).ToList();
        }

        public List<IGrouping<int, XElement>> CalculationOfAverageClientActivityStatisticsByYear()
        {
            AddAllOrders();
            return listOrders.GroupBy(d => Convert.ToDateTime(d.Element("orderdate").Value).Year).ToList();

        }


        public List<IGrouping<string, XElement>> CalculationOfAverageClientActivityStatisticsByMonthAndYear()
        {
            AddAllOrders();
            return listOrders.GroupBy(d => Convert.ToDateTime(d.Element("orderdate").Value).Date.ToString("yyyy-MM")).ToList();
        }
    }
}

