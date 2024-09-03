using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject1.DataAccess.IRepository;
using WebAPIProject1.DatabaseContext;
using WebAPIProject1.Models;

namespace WebAPIProject1.DataAccess.Repository
{
    public class EmpRepository : IEmpRepository
    {
        public DBContextPro EmpDb;
        public EmpRepository(DBContextPro _EmpDb)
        {
            EmpDb = _EmpDb;
        }

        public async Task<List<Employee>> AllEmployees()
        {
            return await EmpDb.Employees.ToListAsync();
        }

        public async Task<int> DeleteAllEmployee()
        {
            EmpDb.Employees.RemoveRange(EmpDb.Employees.ToList());
            return await EmpDb.SaveChangesAsync();
        }
        public async Task<int> DeleteEmployee(int EmpId)
        {
            var Emp = EmpDb.Employees.Find(EmpId);
            EmpDb.Employees.Remove(Emp);
            return await EmpDb.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeeByDeptNo(int DeptNo)
        {
            return await EmpDb.Employees.Where(x => x.DeptNo == DeptNo).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByEmailAndPassword(string Email, string Password)
        {
            return await EmpDb.Employees.Where(x => x.Email == Email && x.Password == Password).SingleOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByEmpId(int EmpId)
        {
            return await EmpDb.Employees.FindAsync(EmpId);
        }

        public async Task<Employee> GetEmployeeByOnlyEmail(string Email)
        {
            return await EmpDb.Employees.Where(x=>x.Email == Email).SingleOrDefaultAsync();
        }

        public async Task<int> InsertEmployee(Employee Emp)
        {
            await EmpDb.Employees.AddAsync(Emp);
            return await EmpDb.SaveChangesAsync();
        }

        public async Task<int> updateEmployee(Employee Emp)
        {
            EmpDb.Employees.Update(Emp);
            return await EmpDb.SaveChangesAsync();
        }
    }
}
       

       

       
    

