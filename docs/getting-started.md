# Getting started

## Install

```bash
dotnet add package Acme.Client
```

## Register the client

In applications using dependency injection:

```csharp
using Acme.Client;
using Acme.Client.DependencyInjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAcmeClient(options =>
{
    options.ApiKey = builder.Configuration["Acme:ApiKey"];
});

// Resolve AcmeClient from DI (for example in a hosted service or minimal API endpoint).
```

For console tools, build a small `ServiceCollection`, call `AddAcmeClient`, and resolve `AcmeClient` from the provider. See [`samples/Acme.Console`](../samples/Acme.Console/Program.cs).

### Tests and advanced scenarios

Inject a test `HttpClient` (for example with `QueuedHttpMessageHandler`):

```csharp
using HttpClient httpClient = new(handler);
AcmeClient client = new(httpClient, apiKey: "test-api-key");
```

## Example calls

```csharp
StatusResponse status = await client.Status.GetAsync();
Console.WriteLine(status.Status ?? "(null)");
```

See [authentication.md](authentication.md) for API keys and [api-coverage.md](api-coverage.md) for the operation list. Maintainer mapping lives in [plan/API_HTTP_REFERENCE.md](../plan/API_HTTP_REFERENCE.md).
