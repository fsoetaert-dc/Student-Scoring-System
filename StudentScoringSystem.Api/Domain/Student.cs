namespace StudentScoringSystem.Api.Domain;

public class Student
{
    public required StudentName StudentName { get; set; }
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Guid Id = Guid.NewGuid();
    public Dictionary<Course, Score> Scores { get; set; } = new();
    public required Address Address { get; set; }
    public Student(StudentName name, DateOnly dateOfBirth)
    {
        StudentName = name;
        Age = AgeCalculator.GetAge(dateOfBirth);
        DateOfBirth = dateOfBirth;
    }
}