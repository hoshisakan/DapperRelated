using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_ConsentTable
{
    public string EmpID { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime? LockTime { get; set; }

    public int PersonType { get; set; }
}
