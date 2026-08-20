namespace StudentScoringSystem.Api.Domain;

public class Student
{
    public string StudentName { get; set; }
    public int Age { get; set; }
    public Dictionary<string, int> Scores { get; set; } = new();

    public Student(string name, int age)
    {
        StudentName = name;
        Age = age;
    }
}