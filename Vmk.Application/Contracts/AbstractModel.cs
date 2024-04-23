namespace Vmk.Application.Contracts;

#nullable enable

public abstract class AbstractModel
{
    public bool IsInvisible { get; set; }

    public int SortNumber { get; set; } = 1000;
}
