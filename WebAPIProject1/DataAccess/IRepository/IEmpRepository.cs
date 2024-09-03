using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProject1.Models;

namespace WebAPIProject1.DataAccess.IRepository
{
    public interface IEmpRepository
    {
        Task<List<Employee>> AllEmployees();   
        Task<Employee> GetEmployeeByEmpId(int EmpId);  
        Task<List<Employee>> GetEmployeeByDeptNo(int DeptNo);
        Task <Employee> GetEmployeeByEmailAndPassword (string Email,string Password);
        Task<Employee> GetEmployeeByOnlyEmail(string Email);
        Task<int> InsertEmployee(Employee Emp);
        Task<int> updateEmployee(Employee Emp);
        Task<int> DeleteEmployee(int EmpId);
        Task<int>DeleteAllEmployee();
    }
}

