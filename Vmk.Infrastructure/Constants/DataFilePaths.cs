namespace Vmk.Infrastructure.Constants;

public static class DataFilePaths
{
    private static string ROOT => Path.Combine("wwwroot", "data");

    public static string GALLERIES => Path.Combine(ROOT, "galleries-data.json");

    public static string TESTIMONIALS => Path.Combine(ROOT, "testimonials-data.json");

    public static string DOS_AND_DONTS => Path.Combine(ROOT, "dosanddonts-data.json");
}
