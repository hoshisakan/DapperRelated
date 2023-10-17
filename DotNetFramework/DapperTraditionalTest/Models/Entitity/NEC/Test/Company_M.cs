using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class Company_M
{
    public string ID { get; set; } = null!;

    public string? P_Name { get; set; }

    public string? P_Sex { get; set; }

    public string? Name { get; set; }

    public byte[]? ImgData_1 { get; set; }

    public byte[]? FetData_1 { get; set; }

    public double? Quality_1 { get; set; }

    public byte[]? ImgData_2 { get; set; }

    public byte[]? FetData_2 { get; set; }

    public double? Quality_2 { get; set; }

    public string Type { get; set; } = null!;

    public string? CancelReason { get; set; }

    public string? CancelTime { get; set; }

    public string? CancelID { get; set; }

    public string CreateID { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string? DataDate { get; set; }

    public string UserID { get; set; } = null!;
}
