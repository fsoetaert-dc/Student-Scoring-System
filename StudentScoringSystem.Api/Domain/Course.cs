namespace StudentScoringSystem.Api.Domain;

public record Course
{
    public string Value;

    public Course(string value) { 
    if (string.IsNullOrWhiteSpace(value))
    { throw new NullReferenceException("Coursename cannot be empty");}


    if (value.Length > 100)
    { throw new Exception("Coursename cannot be longer then 100 characters");}

    Value = value.ToUpper();
    }
}