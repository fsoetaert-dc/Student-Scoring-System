namespace StudentScoringSystem.Api.Domain;

public class Student
{
    public required string StudentName { get; set; }
    public int Age { get; set; }
    public Guid Id = Guid.NewGuid();
    public Dictionary<string, int> Scores { get; set; } = new();
    public string Address { get; set; } = "";
    public Student(string name, DateOnly dateOfBirth)
    {
        StudentName = name;
        Age = AgeCalculator.GetAge(dateOfBirth);
    }
}