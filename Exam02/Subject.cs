namespace Exam02;

public  class Subject
{
    int SubjectId{get;set;}
    string? SubjectName{get;set;}
    public Exam exam{get;set;}

    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreatExam()
    {
        Console.WriteLine("*Enter the type of exam ( 1.Final || 2.Practical )");
        int typeOfExam = int.Parse(Console.ReadLine());
        Console.Write("Enter the time of the exam: ");
        int timeOfExam = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of questions you want to create: ");
        int numberOfQuestions = int.Parse(Console.ReadLine());
        Question question;
        if (typeOfExam == 1)
        {
            exam=new FinalExam(timeOfExam,numberOfQuestions);
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Enter the type of question ( 1.True or False || 2.McqQuestion )");
                int questionType = int.Parse(Console.ReadLine());
                Console.Write($"Enter the header of the question number {i+1}: ");
                string header = Console.ReadLine();
                Console.Write($"Enter the mark of the question number {i+1}: ");
                int mark = int.Parse(Console.ReadLine());
                Console.Write($"Enter the body of the question number {i+1}: ");
                string body = Console.ReadLine();
                if (questionType == 1)
                {
                    question = new TrueOrFalseQuestion(header, body, mark);
                    Console.Write($"Enter the correct answer for question number {i+1}: ");
                    string answer = Console.ReadLine();
                    question.AnswersList.Add(new Answers((i + 1), answer));
                    Console.WriteLine("============================================");
                }
                else
                {
                    Console.Write($"Enter the number of choices for question number {i+1}: ");
                    int choicesnumber = int.Parse(Console.ReadLine());
                    List<string> choices = new List<string>();
                    for (int j = 0; j < choicesnumber; j++)
                    {
                        Console.Write($"Enter the choice {j+1}: ");
                        choices.Add(Console.ReadLine());
                    }
                    
                    question = new McqQuestion(header, body, mark, choices);
                    Console.Write($"Enter the correct answer for question number {i+1}: ");
                    string answer = Console.ReadLine();
                    question.AnswersList.Add(new Answers((i + 1), answer));
                }
                exam.questions.Add(question);
                Console.WriteLine();
            }

        }
        else
        {
            exam=new PracticalExam(timeOfExam, numberOfQuestions);
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Write($"Enter the header of the question number {i+1}:  ");
                string? header = Console.ReadLine();
                Console.Write($"Enter the mark of the question number {i+1}: ");
                int mark = int.Parse(Console.ReadLine());
                Console.Write($"Enter the body of the question number {i+1}: ");
                string? body = Console.ReadLine();
                Console.Write("Enter the number of the choices: ");
                int choicesnumber = int.Parse(Console.ReadLine());
                List<string> choices = new List<string>();
                for (int j = 0; j < choicesnumber; j++)
                {
                    Console.Write($"Enter the choice {j + 1}: ");
                    choices.Add(Console.ReadLine());
                }
                question = new McqQuestion(header, body, mark, choices);
                Console.Write($"Enter the correct answer for question {i+1}: ");
                string answer = Console.ReadLine();
                question.AnswersList.Add(new Answers((i + 1), answer));
                exam.questions.Add(question);
                Console.WriteLine("========================================");
            }
        }
            
        }
    
    }
    