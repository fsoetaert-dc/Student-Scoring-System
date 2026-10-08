namespace StudentScoringSystem.Api.Domain;

public record Course
{
    public Guid Id { get; set; }
    public required CourseName CourseName { get; set; }
    public required Score Score { get; set; }
}