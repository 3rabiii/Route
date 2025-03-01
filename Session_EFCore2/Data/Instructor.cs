using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
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
        public int? Dep_Id {  get; set; }

    }
}
