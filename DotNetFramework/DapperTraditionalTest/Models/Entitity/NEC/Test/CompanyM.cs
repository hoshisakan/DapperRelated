using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class CompanyM
{
    public string Id { get; set; } = null!;

    public string? PName { get; set; }

    public string? PSex { get; set; }

    public string? Name { get; set; }

    public byte[]? ImgData1 { get; set; }

    public byte[]? FetData1 { get; set; }

    public double? Quality1 { get; set; }

    public byte[]? ImgData2 { get; set; }

    public byte[]? FetData2 { get; set; }

    public double? Quality2 { get; set; }

    public string Type { get; set; } = null!;

    public string? CancelReason { get; set; }

    public string? CancelTime { get; set; }

    public string? CancelId { get; set; }

    public string CreateId { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string? DataDate { get; set; }

    public string UserId { get; set; } = null!;
}
