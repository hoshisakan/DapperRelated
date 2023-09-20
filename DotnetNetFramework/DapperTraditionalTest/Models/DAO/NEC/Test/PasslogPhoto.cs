using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class PasslogPhoto
{
    public string LogDateTime { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Source { get; set; }

    public string? AnalyzeNumber { get; set; }
}
