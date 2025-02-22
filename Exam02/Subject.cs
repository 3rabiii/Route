namespace Exam02;

public class Subject
{
    public int SubjectId { get; set; }
    public string? SubjectName { get; set; }
    public Exam? exam { get; set; }

    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreateExam()
    {
        Console.WriteLine("Enter the type of exam (1. Final || 2. Practical)");
        int typeOfExam = int.Parse(Console.ReadLine());
        Console.Write("Enter the time of the exam: ");
        int timeOfExam = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of questions you want to create: ");
        int numberOfQuestions = int.Parse(Console.ReadLine());
        exam = typeOfExam == 1 ? new FinalExam(timeOfExam, numberOfQuestions) : new PracticalExam(timeOfExam, numberOfQuestions);
        for (int i = 0; i < numberOfQuestions; i++)
        {
            exam.questions.Add(CreateQuestion(i + 1));
        }
    }

    private Question CreateQuestion(int questionNumber)
    {
        Console.WriteLine("Enter the type of question (1. True or False || 2. MCQ)");
        int questionType = int.Parse(Console.ReadLine());
        Console.Write($"Enter the header of question {questionNumber}: ");
        string? header = Console.ReadLine();
        Console.Write($"Enter the mark of question {questionNumber}: ");
        int mark = int.Parse(Console.ReadLine());
        Console.Write($"Enter the body of question {questionNumber}: ");
        string? body = Console.ReadLine();

        Question question;
        if (questionType == 1)
        {
            question = new TrueOrFalseQuestion(header, body, mark);
        }
        else
        {
            question = new McqQuestion(header, body, mark, GetChoices());
        }

        Console.Write($"Enter the correct answer for question {questionNumber}: ");
        string? answer = Console.ReadLine();
        question.AnswersList.Add(new Answers(questionNumber, answer));
        Console.WriteLine("========================================");
        return question;
    }

    private List<string> GetChoices()
    {
        Console.Write("Enter the number of choices: ");
        int choicesNumber = int.Parse(Console.ReadLine());
        List<string> choices = new();
        for (int j = 0; j < choicesNumber; j++)
        {
            Console.Write($"Enter choice {j + 1}: ");
            choices.Add(Console.ReadLine());
        }
        return choices;
    }
}
