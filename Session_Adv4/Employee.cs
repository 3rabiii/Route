namespace TaskSession_PAdv4;

public enum LayOffCause
{
    VocationStockIsNegative,
    AgeGreaterThan60,
    FailedToAchieveTarget,
    Resigned
}
public class EmployeeLayOffEventArgs: EventArgs
{
    public LayOffCause Cause { get; set; }
}

public class Employee
{
    public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

    protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        EmployeeLayOff(this ,e);
    }
    public int EmployeeID { get; set; }
    private DateTime birthDate;
    public DateTime BirthDate
    {
        get { return birthDate;}
        set
        { birthDate = value; }
    }

    private int vacationStock;
    public int VacationStock
    {
        get { return vacationStock;}
        set { vacationStock = value; }
    }
    public bool RequestVacation (DateTime From , DateTime To)
    {
        int days =(To - From).Days;
        if (days < VacationStock)
        {
            VacationStock-=days;
            return true;
        }
        return false;
    }
    public virtual void EndOfYearOperation ()
    {
        if (VacationStock < 0)
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(){ Cause = LayOffCause.VocationStockIsNegative});
        }
        int age= DateTime.Now.Year - BirthDate.Year;
        if(age>60) OnEmployeeLayOff(new EmployeeLayOffEventArgs(){ Cause = LayOffCause.AgeGreaterThan60});
    }

    public override string ToString()
    {
        return $"Id:{EmployeeID} | BirthDate:{BirthDate} | VacationStock:{VacationStock}";
    }
}