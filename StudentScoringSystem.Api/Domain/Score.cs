namespace StudentScoringSystem.Api.Domain;

public record Score
{
    public int Value;

    public Score(string number)
    {
        if (!int.TryParse(number, out var value))
            throw new ArgumentException("Not a valid integer.", nameof(number));

        if ((value < 0) || (value > 100))
        { throw new IndexOutOfRangeException("Score must be between 0-100."); }


        Value = value;
    }
}