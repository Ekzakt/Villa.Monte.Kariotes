#nullable disable

using Vmk.Application.Models.Domain;

namespace Vmk.Application.Models
{
    public class YourStayModel
    {
        public List<DoAndDont> Dos { get; set; }

        public List<DoAndDont> Donts { get; set; }
    }
}
