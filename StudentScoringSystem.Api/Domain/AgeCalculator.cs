namespace StudentScoringSystem.Api.Domain;

public static class AgeCalculator
{

    public static int GetAge(DateOnly birthDate)
    {
        var t = DateOnly.FromDateTime(DateTime.Today);

        if (birthDate > t) {throw new IndexOutOfRangeException("Date of Birth is in the furture.");}

        int age = t.Year - birthDate.Year;

        if (t < birthDate.AddYears(age))
            age--;

        return age;
    }
}