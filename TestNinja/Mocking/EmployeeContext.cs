using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }
}