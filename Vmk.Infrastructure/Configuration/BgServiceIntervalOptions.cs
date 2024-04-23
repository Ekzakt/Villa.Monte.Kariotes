namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class BgServiceIntervalOptions
{
    public int Value { get; init; }

    public BgIntervalBetweenOptions ValueBetween { get; init; } = new();
}