namespace StudentScoringSystem.Api.Domain;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string StateOrProvince { get; }
    public int PostalCode { get; }
    public string Country { get; }

    public Address(
        string street,
        string city,
        string stateOrProvince,
        string postalCode,
        string country)
    {
        Street = NormalizeRequired(street, nameof(street));
        City = NormalizeRequired(city, nameof(city));
        StateOrProvince = NormalizeRequired(stateOrProvince, nameof(stateOrProvince));
        var stringPostalCode = NormalizeRequired(postalCode, nameof(postalCode));
        if (!int.TryParse(stringPostalCode, out var value))
            throw new ArgumentException("Not a valid integer.", nameof(stringPostalCode));

        if ((value < 1000) || (value >= 10000))
        { throw new ArgumentOutOfRangeException("Postal code must be between 1000-9999."); }
        PostalCode = value;
        Country = NormalizeRequired(country, nameof(country));
    }

    private static string NormalizeRequired(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{paramName} cannot be empty.", paramName); ;

        if (value.Length > 100)
            throw new ArgumentException($"{paramName} cannot exceed 100 characters.", paramName);


        return value.Trim().ToUpper();
    }
}