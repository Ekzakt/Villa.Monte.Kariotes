namespace Vmk.Infrastructure.Configuration;

#nullable disable

public class QueueNamesOptions
{
    public const string SectionPath = "Vmk:QueueNames";

    public string ContactForm { get; init; }

    public string Emails { get; init; }
}
