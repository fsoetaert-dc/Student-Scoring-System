namespace StudentScoringSystem.Api.Domain;

public class Student
{
    public required StudentName StudentName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Guid Id { get; set; }
    public Dictionary<Course, Score> Scores { get; set; } = new();
    public required Address Address { get; set; }

    
    private static int GetAge(DateOnly birthDate)
    {
        var t = DateOnly.FromDateTime(DateTime.Today);

        if (birthDate > t) {throw new IndexOutOfRangeException("Date of Birth is in the furture.");}

        int age = t.Year - birthDate.Year;

        if (t < birthDate.AddYears(age))
            age--;

        return age;
    }
}