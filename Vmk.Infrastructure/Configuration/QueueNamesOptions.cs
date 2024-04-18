namespace Vmk.Infrastructure.Configuration;

public class QueueNamesOptions
{
    public const string SectionPath = "Vmk:QueueNames";

    public string? ContactForm { get; init; }

    public string? Emails { get; init; }
}
