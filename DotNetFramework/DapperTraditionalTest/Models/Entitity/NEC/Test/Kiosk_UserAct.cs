using System;
using System.Collections.Generic;

namespace Models.Entity.NEC.Test;

public partial class Kiosk_UserAct
{
    public string EmpID { get; set; } = null!;

    public string? EmpName { get; set; }

    public string EmpPwd { get; set; } = null!;

    public string EmpPms { get; set; } = null!;

    public string? Area { get; set; }

    public string? Place { get; set; }

    public string? ChangePwdDate { get; set; }

    public string? LockTime { get; set; }

    public string CreateDate { get; set; } = null!;

    public string? DataDate { get; set; }

    public string UserID { get; set; } = null!;
}
