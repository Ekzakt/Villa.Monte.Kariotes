using Vmk.Application.Contracts;

namespace Vmk.Application.Models;

#nullable disable

public class Testimonal : AbstractModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateOnly DateWritten { get; set; }

    public string Name { get; set; }

    public string CountryOfOrigin { get; set; }

    public string Content { get; set; }

}
