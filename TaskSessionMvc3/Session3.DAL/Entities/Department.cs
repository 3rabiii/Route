namespace Session3.DAL.Entities;

public class Department: ModelBas
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateOnly CreationDate{ get; set; }
}