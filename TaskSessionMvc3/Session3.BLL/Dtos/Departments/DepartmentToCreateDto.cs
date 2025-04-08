namespace Session3.BLL.Dtos.Departments;

public class DepartmentToCreateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateOnly CreationDate{ get; set; }
}