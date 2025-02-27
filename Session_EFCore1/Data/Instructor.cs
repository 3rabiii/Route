using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Bouns {  get; set; }
        public decimal Salary {  get; set; }
        public string? Address {  get; set; }
        public int Hour_Rate {  get; set; }
        public int Dep_Id {  get; set; }

    }
}
