namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class VmkOptions
{
    public const string SectionName = "Vmk";

    public BunnyCdnOptions BunnyCdn { get; init; }

    public QueueNamesOptions QueueNames { get; init; } = new();

    public StorageBaseLocationOptions BaseLocations { get; init; } = new();

    public List<BgServiceOptions> BackgroundServices { get; init; } = [];
}
