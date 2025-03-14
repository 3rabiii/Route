using System.Text.Json;
using TaskSessionEFcore3.Data.Context;
using TaskSessionEFcore3.Data.DomainModels;

namespace TaskSessionEFcore3.Data;

public static class Session3ContextSeed
{
    public static void Seed(TaskSessionEF3Dbcontext dbcontext)
    {
       
        // var departmentFile = File.ReadAllText("/mnt/Track/Courses/Route/Backend/C#Studying/EF Core/Session3/TaskSessionEFcore3/Data/DataSeed/departments.json");
        // var departments = JsonSerializer.Deserialize<List<Department>>(departmentFile);
        // if (!dbcontext.Departments.Any())
        // {
        //     if (departments.Count > 0)
        //     {
        //         dbcontext.Departments.AddRange(departments);
        //         dbcontext.SaveChanges();
        //     }
        // }
        //
        //
        // var employeeFile = File.ReadAllText("/mnt/Track/Courses/Route/Backend/C#Studying/EF Core/Session3/TaskSessionEFcore3/Data/DataSeed/employees.json");
        // var employees = JsonSerializer.Deserialize<List<Employee>>(employeeFile);
        //
        // if (!dbcontext.Employee.Any())  
        // {
        //     if (employees.Count > 0)
        //     { 
        //         dbcontext.Employee.AddRange(employees);  
        //         dbcontext.SaveChanges();
        //     }
        // }
    }
}