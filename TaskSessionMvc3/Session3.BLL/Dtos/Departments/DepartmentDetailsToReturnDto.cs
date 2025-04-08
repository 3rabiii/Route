namespace Session3.BLL.Dtos.Departments;

public class DepartmentDetailsToReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateOnly CreationDate{ get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreateDateOn { get; set; }
    public int LastModifiedBy { get; set; }
    public  DateTime LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}