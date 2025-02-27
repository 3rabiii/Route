using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSessionEFCore1.Data
{
    public class Course_Inst
    {
        [Key]
        public int Inst_Id {  get; set; }
        public int Course_Id {  get; set; }
        public double Evaluate {  get; set; }
    }
}
