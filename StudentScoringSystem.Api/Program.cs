using StudentScoringSystem.Api.Application;
using StudentScoringSystem.Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();

builder.Services.AddScoped<StudentService>();

var app = builder.Build();

app.MapGet("/students", async (StudentService service) => Results.Ok(await service.GetAllStudents()));

app.Run();

public partial class Program;