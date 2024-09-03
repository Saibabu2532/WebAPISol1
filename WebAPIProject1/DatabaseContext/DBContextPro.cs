using Microsoft.EntityFrameworkCore;
using WebAPIProject1.Models;

namespace WebAPIProject1.DatabaseContext
{
    public class DBContextPro :DbContext
    {
        public DBContextPro(DbContextOptions<DBContextPro> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
