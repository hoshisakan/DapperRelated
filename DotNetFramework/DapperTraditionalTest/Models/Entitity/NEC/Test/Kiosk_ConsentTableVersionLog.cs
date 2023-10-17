using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class Kiosk_ConsentTableVersionLog
{
    public string EmpID { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Agree { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime? LockTime { get; set; }

    public int PersonType { get; set; }
}
