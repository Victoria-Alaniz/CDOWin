namespace CDO.Core.DTOs;

public class UpdateReminderDTO {
    public DateTime? date { get; init; }
    public string? description { get; init; }
    public int? clientID { get; init; }
    public string? clientName { get; init; }
    public bool? complete { get; init; }
}