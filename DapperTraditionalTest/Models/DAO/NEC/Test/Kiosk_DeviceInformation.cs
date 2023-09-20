using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_DeviceInformation
{
    public string Location { get; set; } = null!;

    public string DeviceNo { get; set; } = null!;

    public string IP { get; set; } = null!;

    public string? FuncGroup { get; set; }

    public DateTime UpdateTime { get; set; }

    public string UserID { get; set; } = null!;

    public int CardRemainingUp { get; set; }

    public int CardRemainingDown { get; set; }

    public int CardAlertPercent { get; set; }

    public int FilmAlertPercent { get; set; }

    public int RibbonAlertPercent { get; set; }
}
