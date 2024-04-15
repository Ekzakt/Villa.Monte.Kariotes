namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class BunnyCdnOptions
{
    public string Uri { get; init; }

    public string BaseLocation { get; init; }

    public string ThumbnailCssClass { get; init; }

    public string PreviewCssClass { get; init; }
}
