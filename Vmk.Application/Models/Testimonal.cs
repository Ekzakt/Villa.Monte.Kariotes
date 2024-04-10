namespace Vmk.Application.Models;

#nullable disable

public class Testimonal
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateOnly DateWritten { get; set; }

    public string Name { get; set; }

    public string CountryOfOrigin { get; set; }

    public string Content { get; set; }

    public bool IsInvisible { get; set; }
}
