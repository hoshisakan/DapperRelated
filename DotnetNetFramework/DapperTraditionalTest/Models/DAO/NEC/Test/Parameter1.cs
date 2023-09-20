using System;
using System.Collections.Generic;

namespace Models.DAO.NEC.Test;

public partial class Parameter1
{
    public int SN { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public string? Group { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }
}
