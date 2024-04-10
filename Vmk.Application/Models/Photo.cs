namespace Vmk.Application.Models;

#nullable disable

public class Photo
{
    public int Id { get; set; }

    public string FileName { get; set; }

    public string OriginalFileName { get; set; }

    public string Description { get; set; }

    public bool IsVisible { get; set; }

    public int SortNumber { get; set; } = 1000;
}
