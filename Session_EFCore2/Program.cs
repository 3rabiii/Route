using Microsoft.EntityFrameworkCore;
using TaskSessionEFCore1.Data;
using TaskSessionEFCore1.Data.Context;

namespace TaskSessionEFCore1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using TaskSessionEF1Dbcontext dbcontext = new TaskSessionEF1Dbcontext();
            #region Create
            Student student = new Student()
            {
                FName = "adel",
                LName = "kassem",
                Address = "Zagazig",
                Dep_Id = null
            };
            Department department = new Department()
            {
                Name = "IT",
                Inst_Id = null,
                Hiring =new DateTime(2004,6,15)
            };
            Instructor instructor = new Instructor()
            {
                Name = "adel",
                Bouns = 100,
                Salary = 15000,
                Address = "zagazig",
                Hour_Rate =8,
                Dep_Id=null
            };
            Course course = new Course()
            {
                Name = ".net",
                Duration = 120,
                Description = "this course to learn .net using c#",
                Top_Id=null
            };
            Topic topic = new Topic()
            {
                Name = "EFCore"
            };

           // Console.WriteLine(dbcontext.Entry(student).State);
            //dbcontext.Students.Add(student);
            //dbcontext.Departments.Add(department);
            //dbcontext.Instructors.Add(instructor);
            //dbcontext.Courses.Add(course);
            //dbcontext.Topics.Add(topic);
           // Console.WriteLine(dbcontext.Entry(student).State);
          //  dbcontext.SaveChanges();
            //Console.WriteLine(dbcontext.Entry(student).State);


            #endregion

            #region Read
            var Student = dbcontext.Students.Where(s => s.Id == 1).Select(s => s).AsNoTracking();
            foreach(var s in Student) Console.WriteLine($"StudentId= {s.Id} StudentName= {s.FName} StudentLName= {s.LName}");
            #endregion

            #region Update
            var Student2 = dbcontext.Students.Where(s => s.Id == 1).Select(s => s).FirstOrDefault();
            //Student2.FName = "mohamed";
            //dbcontext.SaveChanges();
            //Console.WriteLine($"StudentId= {Student2.Id} StudentName= {Student2.FName} StudentLName= {Student2.LName}");
            #endregion

            #region Delete
            var Student3 = dbcontext.Students.Where(s => s.Id == 1).Select(s => s).FirstOrDefault();
            dbcontext.Remove(Student3);
            dbcontext.SaveChanges();
            #endregion


        }
    }
}
