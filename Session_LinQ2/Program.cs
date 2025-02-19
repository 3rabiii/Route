using System.ComponentModel.DataAnnotations;
using static TaskSession_LinQ2.ListGenerator;
using System.IO;
using System.Reflection;

namespace TaskSession_LinQ2;

class Program
{
    static void Main(string[] args)
    {
        #region ElementOperators

        #region Q1

        // var Result = ProductList.First(p => p.UnitsInStock == 0);
        // Console.WriteLine(Result);

        #endregion
        
        #region Q2

        // var Result = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
        // Console.WriteLine(Result);

        #endregion
        
        #region Q3
        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = Arr.Where(p => p > 5).ElementAt(1);
        // Console.WriteLine(Result);
        #endregion
        #endregion
        
        #region AggregateOperators
        #region Q1
        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result=Arr.Count(a=>a%2!=0);
        // Console.WriteLine(Result);
        #endregion
        
        #region Q2

        // var Result = CustomerList.Select(a=>new{a.CustomerName,a.CustomerID,OrderCount=a.Orders.Count()});
        // foreach(var c in Result) Console.WriteLine(c);

        #endregion
        
        #region Q3
        // var Result=ProductList.Select(p=>new{p.Category,count=ProductList.Count(c=>c.Category==p.Category)}).Distinct();
        // foreach(var p in Result) Console.WriteLine($"Category:{p.Category} Count:{p.count}");
        #endregion
        
        #region Q4
        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = Arr.Sum();
        // Console.WriteLine(Result);
        #endregion
        
        #region Q5

        // string[] Arr = File.ReadAllLines("dictionary_english.txt");
        // var Result = Arr.Select(a=>a.Length).Sum();
        // Console.WriteLine(Result);
        #endregion
        
        #region Q6
        // string[] Arr = File.ReadAllLines("dictionary_english.txt");
        // var Result=Arr.Min(a=>a.Length);
        // Console.WriteLine(Result);
        #endregion
        
        #region Q7
         // string[] Arr = File.ReadAllLines("dictionary_english.txt");
         // var Result=Arr.Max(a=>a.Length);
         // Console.WriteLine(Result);
        #endregion
        
        #region Q8
        // string[] Arr = File.ReadAllLines("dictionary_english.txt");
        // var Result = Arr.Select(a => a.Length).Average();
        // Console.WriteLine(Result);

        #endregion
        
        #region Q9

        // var Result = ProductList.Select(p => new 
        //     { p.Category, Total = ProductList.Where(p2 => p.Category == p2.Category).Sum(p2=>p2.UnitsInStock) }).Distinct();
        // foreach(var p in Result) Console.WriteLine($"Category: {p.Category}, Total: {p.Total}");
        

        #endregion

        #region Q10

        // var Resutl = ProductList.Select(p => new
        //     { p.Category, CheapestPrice=ProductList.Where(p2 => p2.Category == p.Category).Min(price => price.UnitPrice) }).Distinct();
        // foreach(var p in Resutl) Console.WriteLine(p);
        #endregion
        
        #region Q11 
        //  لسة البشمهندس مشرحهاش 
        #endregion

        #region Q12

        // var Resutl = ProductList.Select(p => new
        //     { p.Category, ExpensivePrice=ProductList.Where(p2 => p2.Category == p.Category).Max(price => price.UnitPrice) }).Distinct();
        // foreach(var p in Resutl) Console.WriteLine(p);

        #endregion
        
        #region Q13
        // var Resutl = ProductList.GroupBy(p =>p.Category).Select(p2=> new
        //     { p2.Key, MostExpensivePrice=p2.Where(p3=>p3.UnitPrice==p2.Max(p4 => p4.UnitPrice)) });
        // foreach (var p in Resutl)
        // {
        //     Console.WriteLine($"CategoryName: {p.Key}");
        //     foreach (var product in p.MostExpensivePrice) Console.WriteLine($"ProductName: {product.ProductName} UnitPrice: {product.UnitPrice}");
        // }
        #endregion
        
        #region Q14
        // var Resutl = ProductList.Select(p => new
        //     { p.Category, AveragePrice=ProductList.Where(p2 => p2.Category == p.Category).Average(price => price.UnitPrice) }).Distinct();
        // foreach(var p in Resutl) Console.WriteLine(p);
        #endregion

        #endregion
        
        #region SetOperators
        #region Q1

        // var Result = ProductList.Select(p=>p.Category).Distinct();
        // foreach(var category in Result) Console.WriteLine(category);

        #endregion
        
        #region Q2

        // var Result = ProductList.Select(p => p.ProductName[0]).Union(CustomerList.Select(c => c.CustomerName[0]))
        //     .Distinct();
        // foreach(var letter in Result) Console.WriteLine(letter);

        #endregion
        
        #region Q3

        // var Result = ProductList.Select(p => p.ProductName[0]).Intersect(CustomerList.Select(c => c.CustomerName[0]));
        // foreach(var letter in Result) Console.WriteLine(letter);
        #endregion
        
        #region Q4

        // var Result = ProductList.Select(p => p.ProductName[0]).Except(CustomerList.Select(c => c.CustomerName[0]));
        // foreach(var letter in Result) Console.WriteLine(letter);
        #endregion
        
        #region Q5
        // var Result = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length-3))
        //     .Concat(CustomerList.Select(c => c.CustomerName.Substring(c.CustomerName.Length-3)));
        // foreach(var letter in Result) Console.Write($"{letter} ");
        #endregion

        #endregion
        
        #region PartitioningOperators
        #region Q1

        // var Result = CustomerList.Where(c => c.City == "Washington").SelectMany(o => o.Orders).Take(3);
        // foreach(var c in Result) Console.WriteLine(c);
        #endregion
        
        #region Q2
        // var Result = CustomerList.Where(c => c.City == "Washington").SelectMany(o => o.Orders).Take(2);
        // foreach(var c in Result) Console.WriteLine(c);
        #endregion
        
        #region Q3
        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.TakeWhile((num, i) => num > i);
        // foreach(var num in Result) Console.WriteLine(num);

        #endregion
        
        #region Q4
        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.SkipWhile(num => num % 3 != 0);
        // foreach(var num in Result) Console.WriteLine(num);

        #endregion
        
        #region Q5
        // int [] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = numbers.SkipWhile((num, i) => num > i);
        // foreach(var number in Result) Console.WriteLine(number);

        #endregion

        #endregion
        
        #region QuantifiersOperators
        #region Q1
        // string[] Arr = File.ReadAllLines("dictionary_english.txt");
        // var Result = Arr.Any(a => a == "ei");
        // Console.WriteLine(Result);

        #endregion
        
        #region Q2
        // var Resutl = ProductList.GroupBy(p => p.Category).Where(p2 => p2.Any(p => p.UnitsInStock == 0))
        //     .Select(p3=>new{p3.Key,Products=p3} );
        // foreach (var p in Resutl)
        // {
        //     Console.WriteLine(p.Key);
        //     foreach(var product in p.Products) Console.WriteLine(product);
        // }
        #endregion
        
        #region Q3
        // var Resutl = ProductList.GroupBy(p => p.Category).Where(p2 => p2.All(p => p.UnitsInStock > 0))
        //     .Select(p3=>new{p3.Key,Products=p3} );
        // foreach (var p in Resutl)
        // {
        //     Console.WriteLine(p.Key);
        //     foreach(var product in p.Products) Console.WriteLine(product);
        // }
        #endregion
        #endregion
        
    }
}




































