using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task5._3
{
    class XMLWorker
    {
        public string filePath;
        public XDocument xDoc;
        List<XElement> customers;
        int x = Int32.Parse(Data.x);

        public void ReadXml()
        {
            filePath = Data.filePath;
            xDoc = XDocument.Load(filePath);
            customers = xDoc.Root.Elements().ToList();
        }

        //1.	Выдайте список всех клиентов, чей суммарный оборот 
        //(сумма всех заказов) превосходит некоторую величину X. 
        //    Продемонстрируйте выполнение запроса с различными X 
        //    (подумайте, можно ли обойтись без копирования запроса несколько раз)
        public IEnumerable<XElement> Task1(int x)
        {
            return customers.Where(c => c.Element("orders").Elements("order")
                        .Sum(order => Double.Parse(order.Element("total").Value)) > x);
        }


        public void ShowCostomers()
        {
            IEnumerable<XElement> a = Task1(x);
            var id = a.Select(i => i.Element("id"));

            foreach (var s in id)
            {
                Console.WriteLine(s);
            }
        }


        //2.	Сгруппировать клиентов по странам.
        public void Task2()
        {
            var a = customers.GroupBy(c => c.Element("country").Value).ToDictionary(c => c.Key, c => c.ToList());

            //foreach (var s in a)
            //{

            //    Console.WriteLine(s);
            //}
        }

        //3.	Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X
        public void Task3(int x)
        {
            var b = customers.Where(c => c.Element("orders").Elements("order").Any(order => Double.Parse(order.Element("total").Value) > x));

            //foreach (var s in b)
            //{
            //    Console.WriteLine(s);
            //}

        }

        //4.	Выдайте список клиентов с указанием,
        //начиная с какого месяца какого года они стали клиентами (принять за таковые месяц и год самого первого заказа)
        //
        public void Task4()
        {
            var a = customers.Select(c => c.Element("orders").Elements("order").FirstOrDefault()?.Element("orderdate").Value);
            foreach (var s in a)
            {
                Console.WriteLine(s);
            }
        }


        // 5.	Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу,
        //оборотам клиента(от максимального к минимальному) и имени клиента

        public void Task5()
        {
            var a = customers.Select(c => new
            {
                c = customers,
                data = Convert.ToDateTime(c.Element("orders").Elements("order").FirstOrDefault()?.Element("orderdate").Value),
                sum = c.Element("orders").Elements("order").Sum(order => Double.Parse(order.Element("total").Value)),
                name = c.Element("name").Value
            })
                .OrderBy(d => d.data.Year).
                 ThenBy(d => d.data.Month).
                   ThenByDescending(s => s.sum).
                    ThenBy(n => n.name);


            //foreach (var s in a)
            //{
            //    Console.WriteLine(s);
            //}

        }




    }
}

