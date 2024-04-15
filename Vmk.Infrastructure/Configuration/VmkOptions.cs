namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class VmkOptions
{
    public const string SectionName = "Vmk";

    public BunnyCdnOptions BunnyCdn { get; init; }
}
