using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class GroupAct
{
    public string EmpPms { get; set; } = null!;

    public string FunLocation { get; set; } = null!;

    public string FunGate { get; set; } = null!;

    public string FunCompAdd { get; set; } = null!;

    public string FunCompFile { get; set; } = null!;

    public string FunPass { get; set; } = null!;

    public string FunComp { get; set; } = null!;

    public string FunUser { get; set; } = null!;

    public string FunDiagram { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string UserID { get; set; } = null!;

    public int pk { get; set; }

    public string? Parameter { get; set; }

    public string? OperateLog { get; set; }

    public string? FunGroup { get; set; }

    public string DeviceMonitoring { get; set; } = null!;

    public string WhiteList { get; set; } = null!;
}
