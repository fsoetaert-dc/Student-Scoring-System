using StudentScoringSystem.Api.Application;
using StudentScoringSystem.Api.Application.CreateStudent;
using StudentScoringSystem.Api.Application.UpdateStudent;

namespace StudentScoringSystem.Api.Endpoints;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/students", GetAllStudentsAsync);
        app.MapGet("/students/{name:string}", GetByNameAsync);
        app.MapPost("/students", CreateStudent);
        app.MapPut("/students/{id:guid}", UpdateStudentAsync);
        app.MapDelete("/students/{id:guid} ", DeleteStudent);
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

    public static async Task<IResult> UpdateStudentAsync(UpdateStudentRequest request, StudentService service)
    {
        var response = await service.UpdateStudentAsync(request);
        if (response is null)
            return Results.NotFound();
        return Results.Ok(response);
    }

    public static async Task<IResult> DeleteStudent(Guid id, StudentService service)
    {
        var success = await service.DeleteStudentAsync(id);
        if (!success)
            return Results.NotFound();
        return Results.NoContent();
    }


    
}