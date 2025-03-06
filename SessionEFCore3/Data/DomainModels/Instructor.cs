using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSessionEFcore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data.DomainModels
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public int Bouns {  get; set; }
        public decimal Salary {  get; set; }
        [Required]
        public string? Address {  get; set; }
        public int Hour_Rate {  get; set; }
        
        public Department Department {  get; set; }
        public int DepartmentId {  get; set; }
        public ICollection<Course_Inst> InstructorCourses { get; set; } = new HashSet<Course_Inst>();


    }
}