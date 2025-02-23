namespace Exam02;

public class PracticalExam:Exam
{
    public PracticalExam(int timeOfExam, int numberOfQuestions):base(timeOfExam,numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("********* Practical Exam *******");
        foreach (var question in questions)
        {
            question.ShowQuestion();

            Console.Write("Your answer: ");
            string answer = Console.ReadLine();
            Console.WriteLine("************************************************");
        }
        Console.Clear();
        Console.WriteLine("***** Your result and the correct answers of the questins *****");
        foreach (var result in questions)
        {
            Console.WriteLine($"{result.Header} {result.Body}        CorrectAnswer: {result.AnswersList[0].AnswerText}");
        }
        
    }

    public override string ToString()
    {
        return $"Time of Exam: {TimeOfExam}; Number of Questions: {NumberOfQuestions}";
    }
}