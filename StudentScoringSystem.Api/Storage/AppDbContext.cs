using StudentScoringSystem.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace StudentScoringSystem.Api.Storage;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(student =>
        {
            student.Property(b => b.StudentName)
                .HasConversion(
                    name => name.Value,
                    value => new StudentName(value))
                .HasMaxLength(StudentName.MaxLength);

            student.Property(b => b.DateOfBirth)
                .HasConversion(
                    dateOfBirth => dateOfBirth.ToDateTime(TimeOnly.MinValue),
            value => DateOnly.FromDateTime(value));

            student.Property(student => student.Address);
        });
    }
}
