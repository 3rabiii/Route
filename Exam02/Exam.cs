namespace Exam02;

public class Exam
{
    public int TimeOfExam{get;set;}
    public int NumberOfQuestions{get;set;}
    public List<Question> questions{get;set;}

    public Exam(int timeOfExam, int numberOfQuestions)
    {
        TimeOfExam = timeOfExam;
        NumberOfQuestions = numberOfQuestions;
        questions = new List<Question>();
    }

    public virtual void ShowExam(){}

}