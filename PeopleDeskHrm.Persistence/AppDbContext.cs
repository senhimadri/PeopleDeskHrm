using PeopleDeskHrm.Domain;
using Microsoft.EntityFrameworkCore;

namespace PeopleDeskHrm.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<Designation> Designations { get; set; } = default!;
    public DbSet<SalaryInformation> SalaryInformations { get; set; } = default!;
}
