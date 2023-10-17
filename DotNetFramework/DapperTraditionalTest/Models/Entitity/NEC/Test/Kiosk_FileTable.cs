using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class Kiosk_FileTable
{
    public string File1 { get; set; } = null!;

    public string File2 { get; set; } = null!;

    public string? Account { get; set; }

    public DateTime UpdateTime { get; set; }
}
