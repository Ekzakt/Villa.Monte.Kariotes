namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class BgServiceOptions
{
    public string Name { get; init; }

    public BgServiceIntervalOptions Interval { get; init; } = new();
}
