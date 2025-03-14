namespace TaskSessionEFcore3.Data.DomainModels;

public class FullTimeEmployee:Employee
{
   public decimal Salary { get; set; }
   public DateTime StartDate { get; set; }
}