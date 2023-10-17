using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class ClientLog
{
    public int SN { get; set; }

    public string FactoryArea { get; set; } = null!;

    public string ComputerName { get; set; } = null!;

    public string IP { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? ServerIP { get; set; }

    public string? ServerPort { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LogDateTime { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? AlertCheck { get; set; }
}
