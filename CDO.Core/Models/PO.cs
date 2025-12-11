namespace CDO.Core.Models;

public record class PO(
    string id,
    int clientID,
    string description,
    string? office,
    int? employerID,
    double? unitCost,
    string? unitOfMeasurement,
    Client? client,
    DateTime startDate,
    DateTime endDate
    ) {
    public string? formattedStartDate => startDate.ToString(format: "MM/dd/yyyy");
    public string? formattedEndDate => endDate.ToString(format: "MM/dd/yyyy");
    public string? formattedCost => $"{unitCost:C2}";
}