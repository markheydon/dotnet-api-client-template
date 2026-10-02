namespace Acme.Client;

/// <summary>
/// Configuration for <see cref="AcmeClient"/> when registered via <see cref="DependencyInjection.AcmeClientServiceCollectionExtensions.AddAcmeClient"/>.
/// </summary>
public sealed class AcmeClientOptions
{
    /// <summary>
    /// Example API API key. When omitted, only operations that do not require authentication can succeed.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// API base URL. When omitted, <see cref="AcmeClient.DefaultBaseUrl"/> is used.
    /// </summary>
    public Uri? BaseAddress { get; set; }
}
