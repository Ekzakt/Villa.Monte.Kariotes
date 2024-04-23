namespace Vmk.Application.Contracts;

public interface IFileReader
{
    Task<TData?> GetDataAsync<TData>(string filePath, CancellationToken cancellationToken = default) where TData : class;
}
