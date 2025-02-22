using System.Threading.Channels;

namespace Exam02;

public  class TrueOrFalseQuestion:Question
{
    public TrueOrFalseQuestion(string header, string body, int mark):base(header, body, mark)
    {
    }

    public override void ShowQuestion()
    {
        Console.WriteLine($"True || False Question     Mark({Mark})");
        Console.WriteLine($"Header: {Header}: {Body}");
        Console.WriteLine("1.True             2.False");
        Console.WriteLine("=======================================================");
    }
    public override string ToString()
    {
        return $"TrueOrFalseQuestion({Header}, {Body}, {Mark})";
    }
}