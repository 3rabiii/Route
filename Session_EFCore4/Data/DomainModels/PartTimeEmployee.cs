namespace TaskSessionEFcore3.Data.DomainModels;

public class PartTimeEmployee:Employee
{
    public int CountOfHours { get; set; }
    public decimal HourRate { get; set; }
}