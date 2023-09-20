using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_SystemCodeInfo
{
    public string CodeID { get; set; } = null!;

    public string CodeValue { get; set; } = null!;

    public string CodeGroup { get; set; } = null!;

    public string? Description { get; set; }
}
