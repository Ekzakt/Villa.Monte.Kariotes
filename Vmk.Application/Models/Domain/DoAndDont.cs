using Vmk.Application.Contracts;

namespace Vmk.Application.Models.Domain;

#nullable disable

public class DoAndDont : AbstractModel
{
    public string IconCssClass { get; set; }

    public string Description { get; set; }

    public bool IsDoNot { get; set; }
}
