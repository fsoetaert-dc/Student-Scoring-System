using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Application.StudentList;

public class StudentInfo
{
    public required string StudentName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Guid Id { get; set; }
    public required Address Address { get; set; }

}