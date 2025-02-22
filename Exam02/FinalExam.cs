using System.IO.Pipes;

namespace Exam02;

public class FinalExam:Exam
{
    public FinalExam(int timeOfExam,int numberOfQuestions):base(timeOfExam,numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        int totalMarks = 0;
        int yourMark = 0;

        foreach (var question in questions)
        {
            question.ShowQuestion();
        
            Console.Write("Enter your answer: ");
            string userAnswer = Console.ReadLine();
            Console.WriteLine("****************************************");
        
            if (question.AnswersList.Any(a => a.AnswerText.Equals(userAnswer, StringComparison.OrdinalIgnoreCase)))
            {
                yourMark += question.Mark;
            }
            totalMarks += question.Mark;
        }
       
        Console.WriteLine($"Your Grade: {yourMark} out of {totalMarks}");
    }

    public override string ToString()
    {
        return $"Time of Exam: {TimeOfExam}; Number of Questions: {NumberOfQuestions}";
    }
}