namespace TaskSession_Linq3;

class MatcheWords : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        return SortWord(x) == SortWord(y);
    }

    public int GetHashCode(string obj)
    {
        return SortWord(obj).GetHashCode();
    }

    private string SortWord(string w)
    {
        char[] c = w.ToLower().ToCharArray();
        Array.Sort(c);
        return new string(c);
        
    }
}
class Program
{
    static void Main(string[] args)
    {
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
        
        #region GroupingOperators

        #region Q1

        // List<int> numbers = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        // var Result = numbers.GroupBy(n => n % 5);
        // foreach (var n in Result)
        // {
        //     Console.WriteLine($"numbers with a reminder of {n.Key} when divided by 5: ");
        //     foreach (var number in n)
        //     {
        //         Console.WriteLine(number);
        //     }
        // }

        #endregion
        
        #region Q2
        // string[] Arr = File.ReadAllLines("dictionary_english.txt");
        // var Result = Arr.GroupBy(a => a[0]);
        // foreach (var groub in Result)
        // {
        //     Console.WriteLine(groub.Key);
        //     foreach (var word in groub)
        //     {
        //         Console.WriteLine(word);
        //     }
        // }

        #endregion
        
        #region Q3
        // string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
        //
        // var Result = Arr.GroupBy(a => a, new MatcheWords());
        //
        // foreach (var group in Result)
        // {
        //     Console.WriteLine(group.Key);
        //     foreach(var word in group) Console.WriteLine(word);
        // }

        #endregion

        #endregion
    }
}