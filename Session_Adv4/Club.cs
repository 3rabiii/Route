namespace TaskSession_PAdv4;

public class Club
{
    public int ClubID { get; set; }
    public String ClubName { get; set; }
    List<Employee> Members=new List<Employee>();
    public void AddMember(Employee E)
    {
       Members.Add(E);
       if (E.VacationStock < 0)E.EmployeeLayOff += RemoveMember;
    }
    public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
    {
        Employee? employee = sender as Employee;
        Members.Remove(employee);
        Console.WriteLine($"EmployeeId: {employee.EmployeeID} ClubId:{ClubID} ClumbName:{ClubName} And The Cause Is: {e.Cause}");
    }
}