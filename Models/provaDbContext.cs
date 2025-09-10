using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Prova2.Models;

public class provaDbContext(DbContextOptionsBuilder<provaDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Point> Points => Set<Point>();

    public object Tour { get; internal set; }

    protected override void OnModelCreating(ModuleBuilder model)
    {
        model.Entity<User>();

        model.Entity<Tour>()
            .WhithMany(p => p.Points)
            .HasForeignKey(p => p.PiontID);

        model.Entity<Point>();
            
    }
}

public class ProvaDbContextFactory : IDesignTimeDbContextFactory<provaDbContext>
{
    public provaDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<provaDbContext>();
        var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        options.UseSqlServer(sqlConn);
        return new provaDbContext(options.Options);
    }
}