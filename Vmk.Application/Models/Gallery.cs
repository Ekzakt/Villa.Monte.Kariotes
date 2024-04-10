using System.Security.Cryptography.X509Certificates;

namespace Vmk.Application.Models;

#nullable disable

public class Gallery
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsVisible { get; set; }

    public int SortNumber { get; set; } = 1000;

    public List<Photo> Photos { get; set; } = new();

    public string DataFilterName => Id.ToLower() ?? throw new ArgumentNullException(nameof(Id));
}
