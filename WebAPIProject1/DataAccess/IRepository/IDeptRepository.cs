using System.Collections.Generic;
using WebAPIProject1.Models;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIProject1.DataAccess.IRepository
{
    public interface IDeptRepository
    {
        Task<List<Department>> AllDepartments();  //Declaration Method
        Task<Department> GetDepartmentByDeptNo(int DeptNo); //One More Method
        Task<List<Department>> GetDepartmentByLocation(string Location);
        Task<int> InsertDepartment(Department Dept);
        Task<int> updateDepartment(Department Dept);
        Task<int> DeleteDepartment(int DeptNo);
    }
}
