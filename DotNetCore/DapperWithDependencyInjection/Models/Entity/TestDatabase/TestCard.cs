﻿namespace Models.Entity.TestDatabase;

public partial class TestCard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Attack { get; set; }

    public int HealthPoint { get; set; }

    public int Defense { get; set; }

    public int Cost { get; set; }

    public DateTime CreatedTime { get; set; }
}
