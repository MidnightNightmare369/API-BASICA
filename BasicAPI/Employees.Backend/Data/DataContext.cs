using Microsoft.EntityFrameworkCore;
using Employees.Shared.Entities;

namespace Employees.Backend.Data;

public class DataContext : DbContext 
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().HasIndex(e => e.Id).IsUnique();
        modelBuilder.Entity<Employee>().Property(e => e.Salary).HasPrecision(18, 4);
    }
    
}
