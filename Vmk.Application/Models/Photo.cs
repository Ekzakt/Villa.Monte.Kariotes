namespace Vmk.Application.Models;

#nullable disable

public class Photo
{
    public int Id { get; set; }

    public string RootName { get; set; }

    public string OriginalFileName { get; set; }

    public string Description { get; set; }

    public bool IsVisible { get; set; }

    public int SortNumber { get; set; } = 1000;

    public string FileName => $"{RootName}.jpg";

    public string FileNameSquare => $"{RootName}-sq.jpg";
}
