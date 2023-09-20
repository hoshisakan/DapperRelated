using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_Company_
{
    public string ID { get; set; } = null!;

    public string? Remark { get; set; }

    public string? CreateID { get; set; }

    public string? CreateReason { get; set; }

    public string? CreateSite { get; set; }

    public string Co_Type { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string? TrackMod { get; set; }

    public string? CancelReason { get; set; }

    public string? CancelTime { get; set; }

    public string? CancelID { get; set; }

    public int pk { get; set; }
}
