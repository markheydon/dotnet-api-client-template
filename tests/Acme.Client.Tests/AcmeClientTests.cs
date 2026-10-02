using Acme.Client;
using Acme.Client.Models;
using Acme.Client.Tests.TestSupport;

namespace Acme.Client.Tests;

public sealed class AcmeClientTests
{
    [Fact]
    public async Task Status_GetAsync_ReturnsDeserialisedStatus()
    {
        QueuedHttpMessageHandler handler = new();
        handler.Enqueue(System.Net.HttpStatusCode.OK, """{"status":"ok"}""");

        using HttpClient httpClient = new(handler);
        AcmeClient client = new(httpClient);

        StatusResponse status = await client.Status.GetAsync(TestContext.Current.CancellationToken);

        Assert.Equal("ok", status.Status);
    }
}
