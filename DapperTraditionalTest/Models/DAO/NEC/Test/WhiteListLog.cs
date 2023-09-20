﻿using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class WhiteListLog
{
    public int WhiteListLogId { get; set; }

    public string Id { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string GateNo { get; set; } = null!;

    public DateTime UpdateTime { get; set; }

    public DateTime? LockTime { get; set; }

    public string UserId { get; set; } = null!;
}
