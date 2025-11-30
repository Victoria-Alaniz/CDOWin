using CDO.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDO.Core.DTOs;

public class ClientSummaryDTO {
    // Non-optional fields
    public int id { get; init; }
    public string firstName { get; init; }
    public string lastName { get; init; }
    public string city { get; init; }
    public string state { get; init; }

    // Nullable fields
    public string? address1 { get; init; }
    public string? address2 { get; init; }
    public string? zip { get; init; }

    // Computed Properties
    public string name => $"{lastName}, {firstName}";
}
