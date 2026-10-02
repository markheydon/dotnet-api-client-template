using Acme.Client;
using Acme.Client.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();
services.AddAcmeClient(options => options.ApiKey = Environment.GetEnvironmentVariable("ACME_API_KEY"));

await using ServiceProvider provider = services.BuildServiceProvider();
AcmeClient client = provider.GetRequiredService<AcmeClient>();

var status = await client.Status.GetAsync();
Console.WriteLine(status.Status ?? "(null)");
