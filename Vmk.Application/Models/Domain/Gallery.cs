using Vmk.Application.Contracts;

namespace Vmk.Application.Models.Domain;

#nullable disable

public class Gallery : AbstractModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string CopyRight { get; set; }

    public List<Photo> Photos { get; set; } = [];

    public bool IsActive { get; set; }

    public string DataFilterCssName => Id.ToLower() ?? throw new ArgumentNullException(nameof(Id));
}
