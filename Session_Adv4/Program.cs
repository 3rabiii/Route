using System.Threading.Channels;

namespace TaskSession_PAdv4;

class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee()
        {
            EmployeeID = 10,
            BirthDate = new DateTime(1000,6,15),
            VacationStock = 8,
        };
        Employee emp2 = new Employee()
        {
            EmployeeID = 10,
            BirthDate = new DateTime(2004,6,15),
            VacationStock = -8
        };
        Department d1= new Department()
        {
            DeptID = 1,
            DeptName = "IT"
        };
        d1.AddStaff(emp1);
        d1.AddStaff(emp2);
        Club c = new Club();
        c.AddMember(emp1);
        c.AddMember(emp2);
        emp1.EndOfYearOperation();
        Console.WriteLine("=======================================");
        emp2.EndOfYearOperation();
        Console.WriteLine("=====================================");
        SalesPerson p1 = new SalesPerson()
        {
            EmployeeID = 20,
            BirthDate = new DateTime(1000, 6, 15),
            VacationStock = 8,
            AchievedTarget = 80
        };
        d1.AddStaff(p1);
        p1.EndOfYearOperation();
        Console.WriteLine("=====================================");
        BoardMember bm = new BoardMember()
        {
            EmployeeID = 30,
            BirthDate = new DateTime(2000, 6, 15),
            VacationStock = 8,
        };
        d1.AddStaff(bm);
        bm.Resign();
    }
}