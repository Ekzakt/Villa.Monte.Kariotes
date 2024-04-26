namespace Vmk.Infrastructure.Constants;

public static class DataFilePaths
{
    private static string ROOT => Path.Combine("wwwroot", "data");

    public static string GALLERIES => Path.Combine(ROOT, "galleries-data-en.json");

    public static string TESTIMONIALS => Path.Combine(ROOT, "testimonials-data-en.json");

    public static string FAQS => Path.Combine(ROOT, "faqs-data-en.json");

    public static string ACCOMODATIONS => Path.Combine(ROOT, "accomodations-data-en.json");
}
