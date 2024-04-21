using Vmk.Application.Contracts;

namespace Vmk.Application.Models.Domain;

#nullable disable

public class Accomodation : AbstractModel
{
    public string IconCssClass { get; set; }

    public string Description { get; set; }
}
