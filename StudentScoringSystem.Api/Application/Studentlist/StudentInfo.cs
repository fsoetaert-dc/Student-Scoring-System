using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Application.StudentList;

public class StudentInfo
{
    public required StudentName StudentName { get; set; }
    public int Age { get; set; }
    public Guid Id { get; set; }
    public Dictionary<string, int> Scores { get; set; }
    public string Address { get; set; } = "";

}