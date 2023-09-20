using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_TNF_APAUDITLOG
{
    public int SN { get; set; }

    public string? PROJ_CODE { get; set; }

    public string? USER_ID { get; set; }

    public string? PROC_DATETIME { get; set; }

    public string? CLIENT_IP { get; set; }

    public string? FN_TYPE { get; set; }

    public string? FN_NAME { get; set; }

    public string? FN_STTS { get; set; }

    public string? FN_KEYVALUE { get; set; }

    public string? FN_PROC { get; set; }
}
