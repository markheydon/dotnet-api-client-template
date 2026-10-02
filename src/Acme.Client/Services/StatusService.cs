using Acme.Client.Infrastructure.Http;
using Acme.Client.Models;

namespace Acme.Client.Services;

internal sealed class StatusService : IStatusService
{
    private readonly RestClient _rest;

    internal StatusService(RestClient rest)
    {
        _rest = rest;
    }

    public Task<StatusResponse> GetAsync(CancellationToken cancellationToken = default) =>
        _rest.GetAsync<StatusResponse>("status", cancellationToken);
}
