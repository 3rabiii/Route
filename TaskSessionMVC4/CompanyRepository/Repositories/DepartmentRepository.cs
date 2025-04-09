using Company.Data.Contexts;
using Company.Data.Entites;
using Company.Repository.Interfaces;

namespace Company.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext context) : base(context) 
        {

        }
        
    }
}
