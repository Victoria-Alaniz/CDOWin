namespace CDO.Core.Models;

public record class State(
    int Id,
    string Name,
    int? CountryID,
    string? ShortName
    );
