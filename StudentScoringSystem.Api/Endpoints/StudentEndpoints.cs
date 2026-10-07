using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StudentScoringSystem.Api.Application;

namespace StudentScoringSystem.Api.Endpoints;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/students", GetAllStudentsAsync);
        app.MapGet("/students/{name:string}", GetbyName);
        app.MapPost("/students", CreateStudent);
        app.MapPut("/students/{name:string}", UpdateStudent);
        app.MapDelete("/students", DeleteStudent);// add the missing mapping for the DELETE route here
        return app;
    }

    public static async Task<IResult> GetAllStudentsAsync()
    {
        var students = await StudentService.GetAllStudentNames();
    }



    
}