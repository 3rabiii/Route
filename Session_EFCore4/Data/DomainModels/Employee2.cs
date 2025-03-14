using System.ComponentModel.DataAnnotations;

namespace TaskSessionEFcore3.Data.DomainModels;

public class Employee2
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? EmpName { get; set; }
    [Required]
    public int Age { get; set; }
    public virtual Department Department {  get; set; }
    public int DepartmentId {  get; set; }
}