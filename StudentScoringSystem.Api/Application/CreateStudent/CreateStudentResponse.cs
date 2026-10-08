namespace StudentScoringSystem.Api.Application.CreateStudent;

public record CreateStudentResponse
(
    string StudentName,
    DateOnly DateOfBirth,
    Guid Id,
    AddressResponse Address);

public record AddressResponse
(
    string Street,
    string HouseNumber,
    string City,
    string PostalCode,
    string Country);