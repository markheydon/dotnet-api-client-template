using Acme.Client.Infrastructure.Configuration;
using Acme.Client.Infrastructure.Http;
using Acme.Client.Services;

namespace Acme.Client;

/// <summary>
/// Client for the Example API.
/// </summary>
/// <remarks>
/// Register with <see cref="DependencyInjection.AcmeClientServiceCollectionExtensions.AddAcmeClient"/>.
/// For tests, use <see cref="AcmeClient(HttpClient, string?)"/> with a dedicated <see cref="HttpClient"/>.
/// </remarks>
public sealed class AcmeClient
{
    /// <summary>
    /// Default API v1 base URL (replace when generating your SDK).
    /// </summary>
    public const string DefaultBaseUrl = "https://api.example.com/v1/";

    private readonly HttpClient _httpClient;
    private readonly RestClient _rest;

    /// <summary>
    /// Creates a client that uses the supplied <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">HTTP client instance. The SDK does not mutate <see cref="HttpClient.DefaultRequestHeaders"/>.</param>
    /// <param name="apiKey">Optional API key. When provided, must not be empty or whitespace.</param>
    public AcmeClient(HttpClient httpClient, string? apiKey = null)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        _httpClient = httpClient;
        Uri resolvedBase = ResolveBaseAddress(httpClient, baseAddress: null);
        _rest = new RestClient(httpClient, resolvedBase, NormalizeOptionalApiKey(apiKey));
        Status = new StatusService(_rest);
    }

    /// <summary>
    /// Example read-only resource (replace with your API services).
    /// </summary>
    public IStatusService Status { get; }

    internal HttpClient TestHttpClient => _httpClient;

    internal RestClient TestRestClient => _rest;

    internal string? TestApiKey => _rest.ApiKey;

    private static string? NormalizeOptionalApiKey(string? apiKey)
    {
        if (apiKey is null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key cannot be empty or whitespace.", nameof(apiKey));
        }

        return apiKey;
    }

    private static Uri ResolveBaseAddress(HttpClient httpClient, Uri? baseAddress)
    {
        if (baseAddress is not null)
        {
            return HttpClientConfiguration.NormalizeBaseAddress(baseAddress);
        }

        if (httpClient.BaseAddress is not null)
        {
            return HttpClientConfiguration.NormalizeBaseAddress(httpClient.BaseAddress);
        }

        return HttpClientConfiguration.NormalizeBaseAddress(new Uri(DefaultBaseUrl));
    }
}
