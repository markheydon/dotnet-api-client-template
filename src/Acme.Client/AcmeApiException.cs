using System.Net;

namespace Acme.Client;

/// <summary>
/// Thrown when the Example API API returns a documented error response.
/// </summary>
public sealed class AcmeApiException : AcmeHttpException
{
    /// <summary>
    /// Creates an exception from an API error response.
    /// </summary>
    /// <param name="statusCode">The HTTP status code returned by the API.</param>
    /// <param name="detail">The API error detail message.</param>
    public AcmeApiException(HttpStatusCode statusCode, string detail)
        : base(statusCode, detail)
    {
        Detail = detail;
    }

    /// <summary>
    /// Gets the API error detail message returned by Example API (same value as <see cref="Exception.Message"/>).
    /// </summary>
    public string Detail { get; }
}
