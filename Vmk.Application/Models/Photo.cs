using Vmk.Application.Contracts;

namespace Vmk.Application.Models;

#nullable disable

public class Photo : AbstractModel
{
    public int Id { get; set; }

    public string RootName { get; set; }

    public string OriginalFileName { get; set; }

    public string Description { get; set; }

    public string FileName => $"{RootName}.jpg";

    public string FileNameSquare => $"{RootName}.jpg";
}
