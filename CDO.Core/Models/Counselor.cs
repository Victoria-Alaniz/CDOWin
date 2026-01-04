namespace CDO.Core.Models;

public record class Counselor(
    int Id,
    string Name,
    string? Email,
    string? Phone,
    string? Fax,
    string? Notes,
    string? SecretaryName,
    string? SecretaryEmail
    );
