namespace Session3.DAL.Entities;

public class ModelBas
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreateDateOn { get; set; }
    public int LastModifiedBy { get; set; }
    public  DateTime LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
    
}