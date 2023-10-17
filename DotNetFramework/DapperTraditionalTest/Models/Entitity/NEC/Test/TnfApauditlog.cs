using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class TnfApauditlog
{
    public int Sn { get; set; }

    public string? ProjCode { get; set; }

    public string? UserId { get; set; }

    public string? ProcDatetime { get; set; }

    public string? ClientIp { get; set; }

    public string? FnType { get; set; }

    public string? FnName { get; set; }

    public string? FnStts { get; set; }

    public string? FnKeyvalue { get; set; }

    public string? FnProc { get; set; }
}
