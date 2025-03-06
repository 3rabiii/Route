using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSessionEFcore3.Data.DomainModels;
using TaskSessionEFCore3.Data.DomainModels;

namespace TaskSessionEFCore3.Data.DomainModels
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

      public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}