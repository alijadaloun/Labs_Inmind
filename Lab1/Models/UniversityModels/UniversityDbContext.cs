using Microsoft.EntityFrameworkCore;

namespace Lab1.Models.UniversityModels;

public class UniversityDbContext: DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    public UniversityDbContext()
    {
        
    }
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("public");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=university_schema;Username=ALIJAD;Password=alijad");

}