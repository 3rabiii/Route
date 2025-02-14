namespace TaskSession_PAdv4;

public class BoardMember:Employee
{
    public void Resign ()
    {
        OnEmployeeLayOff(new EmployeeLayOffEventArgs(){Cause = LayOffCause.Resigned});
    }
}