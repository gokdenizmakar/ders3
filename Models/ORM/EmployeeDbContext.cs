using Microsoft.EntityFrameworkCore;  //DbContext sınıfına erişim için

namespace ders3.Models.ORM
{
    public class EmployeeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=EmployeeDb; trusted_connection = true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
