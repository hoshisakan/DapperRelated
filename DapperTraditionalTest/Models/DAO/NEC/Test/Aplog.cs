using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class APLog
{
    public int SN { get; set; }

    public string ServerName { get; set; } = null!;

    public string ServerIP { get; set; } = null!;

    public string? ServerPort { get; set; }

    public string JobName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LogDateTime { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? MSG { get; set; }

    public string? MSG1 { get; set; }

    public string? MSG2 { get; set; }

    public string? AlertCheck { get; set; }
}
