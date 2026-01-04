using CDO.Core.DTOs;

namespace CDO.Core.Models;

public record class Placement(
    string Id,
    int? PlacementNumber,
    string? EmployerID,
    int? ClientID,
    int? CounselorID,
    string? PoNumber,
    string? Supervisor,
    string? SupervisorEmail,
    string? SupervisorPhone,
    string? Position,
    string? Salary,
    float? DaysOnJob,
    string? ClientName,
    string? CounselorName,
    bool? Active,
    string? Website,
    string? DescriptionOfDuties,
    string? NumbersOfHoursWorking,
    string? FirstFiveDays1,
    string? FirstFiveDays2,
    string? FirstFiveDays3,
    string? FirstFiveDays4,
    string? FirstFiveDays5,
    string? DescriptionOfWorkSchedule,
    string? HourlyOrMonthlyWages,
    DateTime? HireDate,
    DateTime? EndDate,

    // Optional Parents
    EmployerDTO? Employer
    ) {
    public string? FormattedHireDate => HireDate?.ToString(format: "MM/dd/yyyy");
    public string? FormattedEndDate => EndDate?.ToString(format: "MM/dd/yyyy");

    public string? FormattedSalary => $"${Salary}";

    public string? FormattedSupervisor {
        get {
            var text = $"{Supervisor}\n{SupervisorPhone}\n{SupervisorEmail}";
            if (string.IsNullOrWhiteSpace(text)) { return null; }
            return text;
        }
    }
}