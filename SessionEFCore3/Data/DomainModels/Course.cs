using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSessionEFCore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data.DomainModels
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Duration { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
        public ICollection<Stud_Course> StudentCourses { get; set; } = new HashSet<Stud_Course>();
        public ICollection<Course_Inst> InstructorCourses { get; set; } = new HashSet<Course_Inst>();

    }
}