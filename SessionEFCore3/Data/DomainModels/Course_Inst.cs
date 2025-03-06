namespace TaskSessionEFcore3.Data.DomainModels;

public class Course_Inst
{
    public int  CourseId { get; set; }
    public int InstructorId { get; set; }
    public double Evaluate { get; set; }
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
}