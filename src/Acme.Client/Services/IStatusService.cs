namespace Acme.Client.Services;

/// <summary>
/// Example read operation (replace with your resource services).
/// </summary>
public interface IStatusService
{
    /// <summary>
    /// Gets API status from <c>GET status</c>.
    /// </summary>
    Task<Models.StatusResponse> GetAsync(CancellationToken cancellationToken = default);
}
