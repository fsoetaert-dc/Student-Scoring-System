using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using StudentScoringSystem.Api.Application.StudentList;

namespace StudentScoringSystem.Api.Tests.IntegrationTests;

public class StudentListTests
{
    private readonly WebApplicationFactory<Program> factory = new();

    [Fact]
    public async Task GetStudentsReturnsStudent()
    {
        var client = factory.CreateClient();
        
        var response = await client.GetAsync("/students");
        var books = await response.Content.ReadFromJsonAsync<List<StudentInfo>>();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        Assert.NotNull(books);
        Assert.Empty(books);
    }
}