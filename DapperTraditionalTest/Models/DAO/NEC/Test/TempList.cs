using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class TempList
{
    public string Location { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public double Temperature { get; set; }

    public DateTime UpdateTime { get; set; }

    public string UserID { get; set; } = null!;

    public string? IP { get; set; }

    public string? Door { get; set; }

    public string? GateType { get; set; }

    public double? SpoofingValue { get; set; }

    public bool? ActiveTemperature { get; set; }
}
