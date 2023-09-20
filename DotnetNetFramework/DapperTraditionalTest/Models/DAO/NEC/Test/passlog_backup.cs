using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class passlog_backup
{
    public string LogDateTime { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public string? ComputerName { get; set; }

    public string? Location { get; set; }

    public string? Region { get; set; }

    public string? HitOrNonhit { get; set; }

    public string? ID { get; set; }

    public string? PHOTO_NO { get; set; }

    public string? ImgFile { get; set; }

    public string? Quality { get; set; }

    public string? Score { get; set; }

    public string? Threshold { get; set; }

    public string? Result1 { get; set; }

    public string? Result2 { get; set; }

    public string? Fail { get; set; }

    public string? HTTPEMS { get; set; }

    public string? MatchStTime { get; set; }

    public string? MatchEdTime { get; set; }

    public string? EMSStTime { get; set; }

    public string? EMSEdTime { get; set; }

    public string? Temperature { get; set; }

    public string? GatePass { get; set; }
}
