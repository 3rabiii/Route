using System.Runtime.InteropServices.Marshalling;
using static TaskSession_LinQ1.ListGenerator;
namespace TaskSession_LinQ1;

class Program
{
    static void Main(string[] args)
    {
        #region RestrictionOperator

        #region Q1
        var Result1 = ProductList.Where(p => p.UnitsInStock == 0);
       // foreach (var product in Result1) Console.WriteLine(product);
        #endregion
        
        #region Q2
        var Result2=ProductList.Where(p=>p.UnitsInStock>0&&p.UnitPrice>3.00m);
        //foreach (var product in Result2) Console.WriteLine(product);
        #endregion
        
        #region Q3
        // string []Arr={"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        // var Result3 = Arr.Where((number,i) => number.Length <i );
        // foreach (var number in Result3) Console.WriteLine(number);

        #endregion

        #endregion
        
        #region OrderingOperator
        #region Q1

        // var Result = ProductList.OrderBy(p => p.ProductName);
        // foreach(var p in Result) Console.WriteLine(p);

        #endregion

        #region Q2

        // String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        // var Result = Arr.Order();
        // foreach(var a in Result) Console.WriteLine(a);
        #endregion

        #region Q3

        // var Result = ProductList.OrderByDescending(p => p.UnitsInStock);
        // foreach(var p in Result) Console.WriteLine(p);
        #endregion

        #region Q4
        // string [] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        // var Result = Arr.OrderBy(a => a.Length).ThenBy(a => a);
        // foreach(var a in Result) Console.WriteLine(a);

        #endregion

        #region Q5
        // String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        // var Result = Arr.OrderBy(a => a.Length).ThenBy(a => a, StringComparer.OrdinalIgnoreCase);
        // foreach(var a in Result) Console.WriteLine(a);
        #endregion

        #region Q6

        // var Result = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
        // foreach(var p in Result) Console.WriteLine(p);
        #endregion

        #region Q7

        // String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        // var Result = Arr.OrderBy(a => a.Length).ThenByDescending(a => a, StringComparer.OrdinalIgnoreCase);
        // foreach(var a in Result) Console.WriteLine(a);


        #endregion

        #region Q8

        string [] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};


        #endregion

        #endregion

        #region TransformationOperator

        #region Q1

        //
        // var Result = ProductList.Select(p => p.ProductName);
        // foreach (var product in Result) Console.WriteLine(product);

        #endregion

        #region Q2

        // String [] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};
        // var Result=words.Select(w=>new{UpperCase=w.ToUpper(),LowerCase=w.ToLower()});
        // foreach(var w in Result) Console.WriteLine(w);

        #endregion

        #region Q3

        // var Result = ProductList.Select(p => new { p.ProductID, p.ProductName, Price = p.UnitPrice });
        // foreach (var product in Result) Console.WriteLine(product);

        #endregion

        #region Q4

        // int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
        // var Result = Arr.Select(((a, i) => new { number = a, InPlace = (a == i) }));
        // Console.WriteLine("Number: In-place?");
        //  foreach(var a in Result) Console.WriteLine($"{a.number}: {a.InPlace}");

        #endregion

        #region Q5

        // int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        // int[] numbersB = { 1, 3, 5, 7, 8 };
        // var Result = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new { a, b }));
        // Console.WriteLine("Pairs where a < b:");
        // foreach(var a in Result) Console.WriteLine($"{a.a} is less than {a.b}");

        #endregion

        #region Q6

        // var Result=CustomerList.SelectMany(c=>c.Orders).Where(o=>o.Total<500.00m);
        // foreach(var c in Result) Console.WriteLine(c);

        #endregion

        #region Q7

        // var Result=CustomerList.SelectMany(c=>c.Orders).Where(o=>o.OrderDate.Year>=1998);
        //  foreach(var c in Result) Console.WriteLine(c);

        #endregion

        #endregion
    }
}
