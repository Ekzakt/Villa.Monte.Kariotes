using System.Security.Cryptography.X509Certificates;
using Vmk.Application.Contracts;

namespace Vmk.Application.Models;

#nullable disable

public class Gallery : AbstractModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Photo> Photos { get; set; } = new();

    public string DataFilterName => Id.ToLower() ?? throw new ArgumentNullException(nameof(Id));
}
