namespace TaskSessionEFcore3.Data.DomainModels;

public class Stud_Course
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public  Student Student { get; set; }
    public  Course Course { get; set; }
}