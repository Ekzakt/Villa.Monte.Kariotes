namespace Vmk.Client.Configuration;

public class AzureKeyVaultOptions
{
    public const string SectionName = "Azure:KeyVault";

    public string VaultUri { get; init; } = string.Empty;
}