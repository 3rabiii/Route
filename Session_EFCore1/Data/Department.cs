using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Inst_Id {  get; set; }
        public DateTime Hiring { get; set; }
    }
}
