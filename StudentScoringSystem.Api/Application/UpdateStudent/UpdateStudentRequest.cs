namespace StudentScoringSystem.Api.Application.UpdateStudent;

public class UpdateStudentRequest
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}