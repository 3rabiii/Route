namespace TaskSession_PAdv4;

public class Department
{
    public int DeptID { get; set; }
    public string DeptName { get; set; }
    List<Employee> Staff=new List<Employee>();
    public void AddStaff (Employee E)
    {
       Staff.Add(E);
       E.EmployeeLayOff += RemoveStaff;
    }
    public void RemoveStaff (object sender , EmployeeLayOffEventArgs e)
    {
        Employee?employee=sender as Employee;
        Staff.Remove (employee);
        Console.WriteLine($"EmployeeId: {employee} And The Cause Is: {e.Cause}");
    }
}