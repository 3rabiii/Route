using Microsoft.EntityFrameworkCore;
using Session3.DAL.Entities;
using Session3.DAL.Presistance.Data;

namespace Session3.DAL.Presistance.Repostories.Departments;

public class DepartmentRepostory : IDepartmentRepostory
{
    private readonly ApplicationDbcontext _dbcontext;

    public DepartmentRepostory(ApplicationDbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<Department> GetAll(bool AsNoTracking = true)
    {
        if(AsNoTracking)return  _dbcontext.Departments.AsNoTracking().ToList();
        return _dbcontext.Departments.ToList();
    }

    public Department? GetById(int id)
    {
        return _dbcontext.Departments.Find(id);
    }

    public int AddDepartment(Department department)
    {
        _dbcontext.Departments.Add(department);
        return _dbcontext.SaveChanges();
    }

    public int UpdateDepartment(Department department)
    {
        _dbcontext.Departments.Update(department);
        return _dbcontext.SaveChanges();
    }

    public int DeleteDepartment(Department department)
    {
         _dbcontext.Departments.Remove(department);
         return _dbcontext.SaveChanges();
    }
}