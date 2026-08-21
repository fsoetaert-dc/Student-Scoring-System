namespace StudentScoringSystem.Api.Domain;

public record StudentName
{
    public string Value { get; }
    public StudentName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        { throw new NullReferenceException("Studentname cannot be empty"); }

        if (value.Length > 100)
        { throw new Exception("Studentname cannot be longer then 100 characters"); }

        var splitName = value.Split(' ');

        var upperSplitName = splitName.Select(p => p.ToUpper()).ToArray();

        var upperName = string.Join(" ", upperSplitName);
        Value = upperName;
    }
}