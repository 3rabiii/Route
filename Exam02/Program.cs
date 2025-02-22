using System.Data;
using System.Diagnostics;

namespace Exam02;

class Program
{
    static void Main(string[] args)
    {
        Subject s = new Subject(10, "c#");
        s.CreatExam();
        Console.Clear();
        Console.WriteLine("Do you want to start Exame ( y || n )");
        if (char.Parse(Console.ReadLine()) == 'y')
        {
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            s.exam.ShowExam();
        }
    }
}