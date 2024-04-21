using Vmk.Application.Models.Domain;

namespace Vmk.Application.Models;

#nullable disable

public class AccomodationsModel
{
    public string Title {  get; set; }

    public string Description { get; set; }

    public List<Accomodation> Accomodations { get; set; } = [];
}
