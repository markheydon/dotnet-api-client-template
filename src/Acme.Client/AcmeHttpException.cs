using System.Net;

namespace Acme.Client;

/// <summary>
/// Thrown when the Example API API returns a non-success HTTP status code.
/// </summary>
public class AcmeHttpException : AcmeException
{
    /// <summary>
    /// Creates an exception for the specified HTTP status code.
    /// </summary>
    /// <param name="statusCode">The HTTP status code returned by the API.</param>
    /// <param name="message">The error message.</param>
    public AcmeHttpException(HttpStatusCode statusCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets the HTTP status code returned by the API.
    /// </summary>
    public HttpStatusCode StatusCode { get; }
}
