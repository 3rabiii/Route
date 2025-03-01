using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LName { get; set; }
        [MaxLength(100)]
        public string? Address {  get; set; }
        public int? Dep_Id {  get; set; }

    }
}
