namespace Exam02;

public abstract class Question: IComparable<Question>
{
    public string? Header{get;set;}
    public string? Body{get;set;}
    public int Mark{get;set;}
    public List<Answers> AnswersList { get; set; } 
    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
        AnswersList = new List<Answers>();
    }

    public abstract void ShowQuestion();

    public int CompareTo(Question? other)
    {
        return this.Mark.CompareTo(other.Mark);
    }

    public override string ToString()
    {
        return $"Header: {Header}\nBody: {Body}";
    }
}