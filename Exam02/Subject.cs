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
        Console.WriteLine("Enter the type of exam ( 1.final || 2.practical )");
        int typeOfExam = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the time of the exam");
        int timeOfExam = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of questions");
        int numberOfQuestions = int.Parse(Console.ReadLine());
        Question question;
        if (typeOfExam == 1)
        {
            exam=new FinalExam(timeOfExam,numberOfQuestions);
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Enter the type of question ( 1.True or False || 2.MCQuestion )");
                int questionType = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the header of the question ");
                string header = Console.ReadLine();
                Console.WriteLine("Enter the mark of the question");
                int mark = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the body of the question");
                string body = Console.ReadLine();
                if (questionType == 1)
                {
                    question = new TrueOrFalseQuestion(header, body, mark);
                    Console.WriteLine("Enter the correct answer");
                    string answer = Console.ReadLine();
                    question.AnswersList.Add(new Answers((i + 1), answer));
                }
                else
                {
                    Console.WriteLine("Enter the number of choices");
                    int choicesnumber = int.Parse(Console.ReadLine());
                    List<string> choices = new List<string>();
                    for (int j = 0; j < choicesnumber; j++)
                    {
                        Console.WriteLine($"Enter the {j + 1}.choice");
                        choices.Add(Console.ReadLine());
                    }

                    question = new McqQuestion(header, body, mark, choices);
                    Console.WriteLine("Enter the correct answer");
                    string answer = Console.ReadLine();
                    question.AnswersList.Add(new Answers((i + 1), answer));
                }
                exam.questions.Add(question);
            }

        }
        else
        {
            exam=new PracticalExam(timeOfExam, numberOfQuestions);
            Console.WriteLine("Enter the header of the question ");
            string? header = Console.ReadLine();
            Console.WriteLine("Enter the body of the question");
            string? body = Console.ReadLine();
            Console.WriteLine("Enter the mark of the question");
            int mark = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Enter the number of choices");
                int choicesnumber = int.Parse(Console.ReadLine());
                List<string> choices = new List<string>();
                for (int j = 0; j < choicesnumber; j++)
                {
                    Console.WriteLine($"Enter the {j + 1}.choice");
                    choices.Add(Console.ReadLine());
                }
                
                question = new McqQuestion(header, body, mark, choices);
                Console.WriteLine("Enter the correct answer");
                string answer = Console.ReadLine();
                question.AnswersList.Add(new Answers((i + 1), answer));
                exam.questions.Add(question);
            }
        }
            
        }
    
    }
    