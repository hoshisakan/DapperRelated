using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Kiosk_CardPrintLog
{
    public int LogId { get; set; }

    public DateTime LogDateTime { get; set; }

    public string? Result { get; set; }

    public string? Description { get; set; }

    public string Mode { get; set; } = null!;

    public string IPAddress { get; set; } = null!;

    public string? Location { get; set; }

    public string? GateNo { get; set; }

    public string PrinterName { get; set; } = null!;

    public string ReaderName { get; set; } = null!;

    public string? ORG_ID { get; set; }

    public string CNAME { get; set; } = null!;

    public string PERSON_CODE { get; set; } = null!;

    public string? ENAME { get; set; }
}
