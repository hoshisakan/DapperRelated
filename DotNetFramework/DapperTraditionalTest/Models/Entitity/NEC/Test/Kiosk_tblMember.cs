using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class Kiosk_tblMember
{
    public string ID { get; set; } = null!;

    public string? Name { get; set; }

    public string? EnrollImage { get; set; }

    public string? EnrollFeature { get; set; }

    public string? Gender { get; set; }

    public string? refA { get; set; }

    public string? refB { get; set; }

    public string? refC { get; set; }

    public string? TWAT { get; set; }

    public string? Birthday { get; set; }

    public string? EmployeeID { get; set; }

    public string? MoblieBarcode { get; set; }

    public string? CardNo { get; set; }

    public string? ICardNo { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? IsPwd { get; set; }
}
