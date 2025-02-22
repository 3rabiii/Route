using System.Security;

namespace Exam02;

public class PracticalExam:Exam
{
    public PracticalExam(int timeOfExam, int numberOfQuestions):base(timeOfExam,numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        foreach (var question in questions)
        {
            question.ShowQuestion();

            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine();
            Console.WriteLine("************************************************");
        }
    }

    public override string ToString()
    {
        return $"Time of Exam: {TimeOfExam}; Number of Questions: {NumberOfQuestions}";
    }
}