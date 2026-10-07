namespace StudentScoringSystem.Api.Domain;

public record Address
{
    public string Street { get; }
    public int HouseNumber { get; }
    public string City { get; }
    public int PostalCode { get; }
    public string Country { get; }

    public Address(
        string street,
        string houseNumber,
        string city,
        string postalCode,
        string country)
    {
        Street = NormalizeRequired(street, nameof(street));
        var stringHouseNumber = NormalizeRequired(houseNumber, nameof(houseNumber));
        if (!int.TryParse(stringHouseNumber, out var valueHouseNumber))
            throw new ArgumentException("Not a valid integer.", nameof(stringHouseNumber));
        HouseNumber = valueHouseNumber;
        City = NormalizeRequired(city, nameof(city));
        var stringPostalCode = NormalizeRequired(postalCode, nameof(postalCode));
        if (!int.TryParse(stringPostalCode, out var valuePotalCode))
            throw new ArgumentException("Not a valid integer.", nameof(stringPostalCode));

        if ((valuePotalCode < 1000) || (valuePotalCode >= 10000))
        { throw new ArgumentOutOfRangeException("Postal code must be between 1000-9999."); }
        PostalCode = valuePotalCode;
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