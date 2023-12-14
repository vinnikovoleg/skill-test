using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Salary> Salaries { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
}