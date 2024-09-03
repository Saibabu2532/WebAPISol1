using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProject1.DataAccess.IRepository;
using WebAPIProject1.Models;
using WebAPIProject1.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebAPIProject1.DataAccess.Repository
{
    public class DeptRepository : IDeptRepository
    {
        public DBContextPro DeptDb;

        public DeptRepository (DBContextPro _DeptDb)  //Object Creation 
        {
            DeptDb = _DeptDb;
        }

        //DRL/DQL Sql Command Operation
        public async Task<List<Department>> AllDepartments()
        {
           //Logic to use Entity Framework Class To Read All The Data From Department Database Table
          return await  DeptDb.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartmentByDeptNo(int DeptNo)
        {
            return await DeptDb.Departments.FindAsync(DeptNo);
        }
        public async Task<List<Department>> GetDepartmentByLocation(string Location)
        {
          return await  DeptDb.Departments.Where(x=>x.Location == Location).ToListAsync();
        }

        //DML Commands Sql Operation :
        public async Task<int> InsertDepartment(Department Dept)
        {
            await DeptDb.Departments.AddAsync(Dept); //It Is Not Enough
            return await DeptDb.SaveChangesAsync(); //It will Commite The Db and returns effected count value
        }

        public async Task<int> updateDepartment(Department Dept)
        {
            DeptDb.Departments.Update(Dept);
            return await DeptDb.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptNo)
        {
            var Dept = DeptDb.Departments.Find(DeptNo);
            DeptDb.Departments.Remove(Dept);
            return await DeptDb.SaveChangesAsync();
        }
    }
}
