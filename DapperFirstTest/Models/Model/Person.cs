using System;
using System.Collections.Generic;

namespace Models.Model;

public partial class Person
{
    public int PersonId { get; set; }

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }
}
