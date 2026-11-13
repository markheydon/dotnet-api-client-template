# Authentication

Replace this page with your upstream API's auth model (API key header, OAuth, and similar).

The template uses an optional API key on `AcmeClientOptions.ApiKey`. When set, `RestClient` attaches it according to your API contract (query or header - implement in `HttpClientConfiguration` / `RestClient`).

## SDK usage

```csharp
using Acme.Client.DependencyInjection;

builder.Services.AddAcmeClient(options =>
{
    options.ApiKey = apiKey;
});
```

When registering via `AddAcmeClient`, `AcmeClientOptions.ApiKey` should be `null` or a non-whitespace value. For manual construction, pass `null` or a non-whitespace key to `AcmeClient(HttpClient, string?)`.

Treat credentials as secrets. Do not commit them to source control.

## Environment variables (samples)

| Variable | Purpose |
|----------|---------|
| `ACME_API_KEY` | API key for [`samples/Acme.Console`](../samples/Acme.Console/Program.cs) |

Default CI jobs use mocked HTTP only. Add optional live smoke workflows in the child repository when needed.
