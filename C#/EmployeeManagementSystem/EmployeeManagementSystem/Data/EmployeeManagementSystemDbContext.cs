using EmployeeManagementSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeManagementSystemDbContext :DbContext
    { 
        public EmployeeManagementSystemDbContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
