using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class WhiteList_Log
{
    public int WhiteListLogId { get; set; }

    public string ID { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public DateTime UpdateTime { get; set; }

    public DateTime? LockTime { get; set; }

    public string UserID { get; set; } = null!;
}
