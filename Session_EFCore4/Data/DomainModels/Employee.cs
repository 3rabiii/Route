using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSessionEFcore3.Data.DomainModels;

public class Employee
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //[Required]
    //[MaxLength(50)]
    public string? EmpName { get; set; }
    //[Required]
    public int Age { get; set; }
    // [EmailAddress]
    // public string Email { get; set; }
    // public decimal Salary { get; set; }
    // [MaxLength(100)]
    // public string? Address {  get; set; }
    // public virtual Department Department {  get; set; }
    // public int DepartmentId {  get; set; }
   
}