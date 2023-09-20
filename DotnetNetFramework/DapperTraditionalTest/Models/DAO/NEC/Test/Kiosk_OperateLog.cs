using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_OperateLog
{
    public int SN { get; set; }

    public string EmployeeID { get; set; } = null!;

    public DateTime ActionTime { get; set; }

    public string Action { get; set; } = null!;

    public string ActionContent { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedTime { get; set; }

    public string? Syscode { get; set; }

    public string? ID { get; set; }

    public string? UserName { get; set; }

    public string? IP { get; set; }
}
