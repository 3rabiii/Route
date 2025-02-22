namespace Exam02;

public  class Question
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

    public virtual void ShowQuestion(){}

    public override string ToString()
    {
        return $"Header: {Header}\nBody: {Body}";
    }
}