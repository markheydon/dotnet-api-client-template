using Acme.Client.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Acme.Client.DependencyInjection;

/// <summary>
/// Registers <see cref="AcmeClient"/> with the HTTP client factory (<c>AddHttpClient</c>).
/// </summary>
public static class AcmeClientServiceCollectionExtensions
{
    /// <summary>
    /// Adds a typed <see cref="AcmeClient"/> and configures its <see cref="HttpClient"/> base address from options.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Optional callback to configure <see cref="AcmeClientOptions"/>.</param>
    /// <returns>The <see cref="IHttpClientBuilder"/> for further HTTP configuration (for example resilience handlers).</returns>
    public static IHttpClientBuilder AddAcmeClient(
        this IServiceCollection services,
        Action<AcmeClientOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        AcmeClientOptions options = new();
        configure?.Invoke(options);
        ValidateOptionalApiKey(options.ApiKey);

        services.TryAddSingleton(options);

        return services
            .AddHttpClient<AcmeClient>()
            .ConfigureHttpClient((_, httpClient) =>
            {
                Uri baseAddress = options.BaseAddress is not null
                    ? HttpClientConfiguration.NormalizeBaseAddress(options.BaseAddress)
                    : HttpClientConfiguration.NormalizeBaseAddress(new Uri(AcmeClient.DefaultBaseUrl));

                httpClient.BaseAddress = baseAddress;
            })
            .AddTypedClient<AcmeClient>((httpClient, serviceProvider) =>
            {
                AcmeClientOptions resolvedOptions = serviceProvider.GetRequiredService<AcmeClientOptions>();
                return new AcmeClient(httpClient, resolvedOptions.ApiKey);
            });
    }

    private static void ValidateOptionalApiKey(string? apiKey)
    {
        if (apiKey is null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key cannot be empty or whitespace.");
        }
    }
}
