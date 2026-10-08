using StudentScoringSystem.Api.Application;
using StudentScoringSystem.Api.Application.CreateStudent;

namespace StudentScoringSystem.Api.Endpoints;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/students", GetAllStudentsAsync);
        app.MapGet("/students/{name:string}", GetByNameAsync);
        app.MapPost("/students", CreateStudent);
        app.MapPut("/students/{name:string}", UpdateStudent);
        app.MapDelete("/students", DeleteStudent);
        return app;
    }

    public static async Task<IResult> GetAllStudentsAsync(StudentService service)
    {
        var students = await service.GetAllStudentsAsync();
        return Results.Ok(students);
    }

    public static async Task<IResult> GetByNameAsync(string name, StudentService service)
    {
        var student = await service.GetByNameAsync(name);
        if (student is null)
            return Results.NotFound();
        return Results.Ok(student);
    }

    public static async Task<IResult> CreateStudent(CreateStudentRequest request, StudentService service)
    {
        var response = await service.CreateStudent(request);
        return Results.Created($"/students/{response.StudentName}", response);
    }

    public static async Task<IResult> UpdateStudent(string name, CreateStudentRequest request, StudentService service)
    {
        var response = await service.UpdateStudent(name, request);
        if (response is null)
            return Results.NotFound();
        return Results.Ok(response);
    }

    public static async Task<IResult> DeleteStudent(string name, StudentService service)
    {
        var success = await service.DeleteStudent(name);
        if (!success)
            return Results.NotFound();
        return Results.NoContent();
    }


    
}