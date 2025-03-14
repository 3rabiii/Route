using Microsoft.EntityFrameworkCore;
using TaskSessionEFcore3.Data;
using TaskSessionEFcore3.Data.Context;
using TaskSessionEFcore3.Data.DomainModels;

namespace TaskSessionEFcore3;

class Program
{
    static void Main(string[] args)
    {
        TaskSessionEF3Dbcontext dbcontext = new TaskSessionEF3Dbcontext();

        #region DataSeeding

        //Session3ContextSeed.Seed(dbcontext);

        #endregion

        #region ExplicitLoading

        // var employees = (from E in dbcontext.Employee
        //     where E.DepartmentId == 1
        //     select E).ToList();
        // foreach (var employee in employees)
        // {
        //     if (employee is not null)
        //     {
        //         dbcontext.Entry(employee).Reference(nameof(Employee.Department)).Load();
        //         Console.WriteLine($"EmpName: {employee.EmpName} EmpId: {employee.Id} DepartmentName: {employee.Department?.Name ?? "NoDepartment"}");
        //     }
        // }

        #endregion

        #region EagerLoading

        // var departments = (from d in dbcontext.Departments.Include(d => d.Employee)
        //     where d.Id==1
        //     select d).FirstOrDefault();
        // Console.WriteLine($"DepartmentName: {departments.Name}");
        // foreach (var employee in departments.Employee)
        // {
        //     Console.WriteLine($"EmployeeId: {employee.Id} EmployeeName: {employee.EmpName}");
        // }
        
        #endregion
        
        #region LazyLoading
        // var employees = (from E in dbcontext.Employee
        //     where E.DepartmentId == 1
        //     select E).ToList();
        // foreach (var employee in employees)
        // {
        //     if (employee is not null)
        //     {
        //         Console.WriteLine($"EmpName: {employee.EmpName} EmpId: {employee.Id} DepartmentName: {employee.Department?.Name }");
        //     }
        // }
        #endregion
        
        #region Join

        #region QuerySyntax

        // var result = from E in dbcontext.Employee
        //     join D in dbcontext.Departments
        //         on E.DepartmentId equals D.Id
        //     select new
        //     {
        //        EmployeeId= E.Id,
        //         E.EmpName,
        //         DepartmentId= D.Id,
        //         D.Name
        //     };
        //foreach(var item in result) Console.WriteLine(item);

        #endregion
        
        #region FluentSyntax

        // var result = dbcontext.Employee.Join(
        //     dbcontext.Departments,
        //     E => E.DepartmentId,
        //     D => D.Id,
        //     (E, D) => new
        //     {
        //         EmployeeId = E.Id,
        //         E.EmpName,
        //         DepartmentId = D.Id,
        //         D.Name
        //     }
        // );
        // foreach(var item in result) Console.WriteLine(item);

        #endregion

        #endregion
        
        #region GroupJoin
        
        #region FluentSyntax

        // var result = dbcontext.Departments.GroupJoin(
        //     dbcontext.Employee,
        //     D => D.Id,
        //     E => E.DepartmentId,
        //     (D, E) => new
        //     {
        //         D, E
        //     }
        // ).Where(E=>E.E.Count()>0);
        // foreach (var item in result)
        // {
        //     Console.WriteLine($"DepartmentName: {item.D.Name}");
        //     foreach(var employee in  item.E) Console.WriteLine($"EmployeeId: {employee.Id} EmployeeName: {employee.EmpName}");
        // }

        #endregion

        #region QuerySyntax

        // var result = (from D in dbcontext.Departments
        //     join E in dbcontext.Employee
        //         on D.Id equals E.DepartmentId
        //         into employees
        //     select new { D, employees }).Where(E=>E.employees.Count()>0);
        // foreach (var item in result)
        // {
        //     Console.WriteLine($"DepartmentName: {item.D.Name}");
        //     foreach(var employee in  item.employees) Console.WriteLine($"EmployeeId: {employee.Id} EmployeeName: {employee.EmpName}");
        // }

        #endregion

        #endregion
        
        #region LeftJoin
        
        #region FluentSyntax

        // var result = dbcontext.Departments.GroupJoin(
        //     dbcontext.Employee,
        //     D => D.Id,
        //     E => E.DepartmentId,
        //     (D, E) => new { D, Employees=E.DefaultIfEmpty() }
        // ).SelectMany(X => X.Employees, (X, e) => new { X.D, e });
        // foreach(var item in  result)
        //     Console.WriteLine($"DeptName: {item.D.Name} EmployeeId: {item.e?.Id??0} EmployeeName: {item.e?.EmpName??"NULL"}");
        #endregion
        
        #region QuerySyntax

        // var result = from D in dbcontext.Departments
        //     join E in dbcontext.Employee
        //         on D.Id equals E.DepartmentId
        //         into Employees
        //     select new
        //     {
        //         D,
        //         Employees= Employees.DefaultIfEmpty()
        //     }
        //     into X
        //     from e in X.Employees
        //     select new
        //     {
        //         X.D,
        //         e
        //     }; 
        // foreach(var item in result)
        //     Console.WriteLine($"DeptName: {item.D.Name} EmployeeId: {item.e?.Id??0} EmployeeName: {item.e?.EmpName??"NULL"}");

        #endregion

        #endregion
        
        #region CrossJoin
        
        // var result = from E in dbcontext.Employee
        //     from D in dbcontext.Departments
        //     select new { E,D};
        // foreach(var item in result) Console.WriteLine($"{item.E.EmpName} : {item.D.Name}");
        #endregion
        
        #region TBCC
        // FullTimeEmployee  fullTimeEmployee = new FullTimeEmployee()
        // {
        //     Age = 20,
        //     EmpName = "adel",
        //     Salary = 20000,
        //     StartDate = DateTime.Now
        // };
        // PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
        // {
        //     Age = 30,
        //     EmpName = "mohamed",
        //     CountOfHours = 100,
        //     HourRate = 8
        //
        // };
        // dbcontext.fullTimeEmployees.Add(fullTimeEmployee);
        // dbcontext.partTimeEmployees.Add(partTimeEmployee);
        // dbcontext.SaveChanges();


        #endregion

        #region TPH
        FullTimeEmployee  fullTimeEmployee = new FullTimeEmployee()
        {
            Age = 20,
            EmpName = "adel",
            Salary = 20000,
            StartDate = DateTime.Now
        };
        PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
        {
            Age = 30,
            EmpName = "mohamed",
            CountOfHours = 100,
            HourRate = 8
        
        };
        // dbcontext.fullTimeEmployees.Add(fullTimeEmployee);
        // dbcontext.partTimeEmployees.Add(partTimeEmployee);
        //dbcontext.SaveChanges();
        // dbcontext.Employees.Add(fullTimeEmployee);
        // dbcontext.Employees.Add(partTimeEmployee);
        // dbcontext.SaveChanges();
        // var resutl = from E in dbcontext.Employees
        //     select E;
        // foreach(var emp in resutl.OfType<PartTimeEmployee>()) Console.WriteLine($"EmpName: {emp.EmpName} :  CountOfHours: {emp.CountOfHours}");


        #endregion
        
        #region MappingView

        // var result = from V in dbcontext.EmployeeDepartmentViews
        //     select V;
        // foreach(var item in result)
        //     Console.WriteLine($"EmployeeId: {item.EmployeeId} : EmpName: {item.EmployeeName} DeptId: {item.DepartmentId} DeptName: {item.DepartmentName}");

        #endregion
        

    }
}