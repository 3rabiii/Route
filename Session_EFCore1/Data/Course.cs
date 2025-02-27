using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
{
    public class Course
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Top_Id {  get; set; }
    }
}
