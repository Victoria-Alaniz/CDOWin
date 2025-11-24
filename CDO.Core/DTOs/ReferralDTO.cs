namespace CDO.Core.DTOs;

public class ReferralDTO {
    public int? placementNumber { get; init; }
    public string? employerID { get; init; }
    public int? clientID { get; init; }
    public int? counselorID { get; init; }
    public string? poNumber { get; init; }
    public string? supervisor { get; init; }
    public string? supervisorEmail { get; init; }
    public string? supervisorPhone { get; init; }
    public string? position { get; init; }
    public string? salary { get; init; }
    public float? daysOnJob { get; init; }
    public string? clientName { get; init; }
    public string? counselorName { get; init; }
    public bool? active { get; init; }
    public string? website { get; init; }
    public string? descriptionOfDuties { get; init; }
    public string? numbersOfHoursWorking { get; init; }
    public string? firstFiveDays1 { get; init; }
    public string? firstFiveDays2 { get; init; }
    public string? firstFiveDays3 { get; init; }
    public string? firstFiveDays4 { get; init; }
    public string? firstFiveDays5 { get; init; }
    public string? descriptionOfWorkSchedule { get; init; }
    public string? hourlyOrMonthlyWages { get; init; }
    public DateTime? hireDate { get; init; }
    public DateTime? endDate { get; init; }
}