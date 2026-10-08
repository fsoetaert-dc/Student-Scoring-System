using Microsoft.EntityFrameworkCore;
using StudentScoringSystem.Api.Application;
using StudentScoringSystem.Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("StudentScoringSystem"));
});

builder.Services.AddScoped< EfStudentRepository>();

builder.Services.AddScoped<StudentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
    }
}

app.Run();

public partial class Program;