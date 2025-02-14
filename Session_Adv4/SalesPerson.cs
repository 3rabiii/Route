namespace TaskSession_PAdv4;

public class SalesPerson:Employee
{
    public int AchievedTarget { get; set; }
    public bool CheckTarget (int Quota)
    {
        return AchievedTarget>=Quota;
    }

    public override void EndOfYearOperation()
    {
        if (!CheckTarget(100))
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(){Cause = LayOffCause.FailedToAchieveTarget});
        }
    }
}