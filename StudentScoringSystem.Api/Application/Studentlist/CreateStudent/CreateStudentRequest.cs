using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Application.StudentList.CreateStudent;

public record CreateStudentRequest
{
    public required string StudentName {get;set;}
    public required DateOnly DateOfBirth {get;set;}
    public required string HouseNumber {get;set;}
    public required string Street {get;set;}
    public required string City {get;set;}
    public required string PostalCode {get;set;}
    public required string Country {get;set;}

}