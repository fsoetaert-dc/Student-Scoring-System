using StudentScoringSystem.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace StudentScoringSystem.Api.Storage;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
}