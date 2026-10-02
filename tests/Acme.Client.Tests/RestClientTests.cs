using System.Net;
using Acme.Client;
using Acme.Client.Infrastructure.Http;
using Acme.Client.Models;
using Acme.Client.Tests.TestSupport;

namespace Acme.Client.Tests;

public sealed class RestClientTests
{
    [Fact]
    public void BuildRequestUri_WithApiKey_AppendsQueryParameter()
    {
        using HttpClient httpClient = new();
        RestClient rest = new(httpClient, new Uri(AcmeClient.DefaultBaseUrl), "test-key");

        Uri uri = rest.BuildRequestUri("status");

        Assert.Equal(
            "https://api.example.com/v1/status?api_key=test-key",
            uri.AbsoluteUri);
    }

    [Fact]
    public async Task GetAsync_WhenSuccess_DeserialisesResponse()
    {
        QueuedHttpMessageHandler handler = new();
        handler.Enqueue(HttpStatusCode.OK, """{"status":"ok"}""");

        using HttpClient httpClient = new(handler);
        RestClient rest = new(httpClient, new Uri(AcmeClient.DefaultBaseUrl), apiKey: null);

        StatusResponse response = await rest.GetAsync<StatusResponse>(
            "status",
            TestContext.Current.CancellationToken);

        Assert.Equal("ok", response.Status);
    }

    [Fact]
    public async Task GetAsync_WhenUnauthorized_ThrowsAcmeApiException()
    {
        QueuedHttpMessageHandler handler = new();
        handler.Enqueue(HttpStatusCode.Unauthorized, "\"Unauthorized\"");

        using HttpClient httpClient = new(handler);
        RestClient rest = new(httpClient, new Uri(AcmeClient.DefaultBaseUrl), apiKey: null);

        AcmeApiException exception = await Assert.ThrowsAsync<AcmeApiException>(
            () => rest.GetAsync<StatusResponse>("status", TestContext.Current.CancellationToken));

        Assert.Equal(HttpStatusCode.Unauthorized, exception.StatusCode);
        Assert.Equal("Unauthorized", exception.Detail);
    }
}
