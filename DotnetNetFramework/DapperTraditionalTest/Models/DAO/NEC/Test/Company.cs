using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Company
{
    public string Id { get; set; } = null!;

    public string? Remark { get; set; }

    public string? CreateId { get; set; }

    public string? CreateReason { get; set; }

    public string? CreateSite { get; set; }

    public string CoType { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string? TrackMod { get; set; }

    public string? CancelReason { get; set; }

    public string? CancelTime { get; set; }

    public string? CancelId { get; set; }

    public int Pk { get; set; }
}
