using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class PasslogBackup
{
    public string LogDateTime { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public string? ComputerName { get; set; }

    public string? Location { get; set; }

    public string? Region { get; set; }

    public string? HitOrNonhit { get; set; }

    public string? Id { get; set; }

    public string? PhotoNo { get; set; }

    public string? ImgFile { get; set; }

    public string? Quality { get; set; }

    public string? Score { get; set; }

    public string? Threshold { get; set; }

    public string? Result1 { get; set; }

    public string? Result2 { get; set; }

    public string? Fail { get; set; }

    public string? Httpems { get; set; }

    public string? MatchStTime { get; set; }

    public string? MatchEdTime { get; set; }

    public string? EmsstTime { get; set; }

    public string? EmsedTime { get; set; }

    public string? Temperature { get; set; }

    public string? GatePass { get; set; }
}
