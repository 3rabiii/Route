namespace Exam02;

public class McqQuestion:Question
{
    private List<string> Choices;
    
    public McqQuestion(string header, string body, int mark,List<string>choices):base(header, body, mark)
    {
        Choices = choices;
    }
    public override void ShowQuestion()
    {
        Console.WriteLine($"*Please choose one answer only           *Mark({Mark})");
        Console.WriteLine($"{Header}: {Body}");
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Choices[i]}");
        }
        Console.WriteLine("=============================================");
    }
    
    public override string ToString()
    {
        return $"McqQuestion({Header}, {Body}, {Mark})";
    }
}