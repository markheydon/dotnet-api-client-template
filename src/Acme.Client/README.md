# Acme.Client

Replace with your unofficial .NET API client summary.

## Install

```bash
dotnet add package Acme.Client
```

## Quick example

```csharp
using Acme.Client;
using Acme.Client.DependencyInjection;

builder.Services.AddAcmeClient(options => options.ApiKey = "your-api-key");

AcmeClient client = /* resolve from DI */;
var status = await client.Status.GetAsync();
```

## Documentation

Consumer docs: replace with your GitHub Pages URL.

Source: [github.com/markheydon/your-api-client](https://github.com/markheydon/your-api-client)
