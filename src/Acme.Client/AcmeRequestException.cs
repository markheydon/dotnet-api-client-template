namespace Acme.Client;

/// <summary>
/// Thrown when a request violates a local contract constraint before any HTTP call is made.
/// </summary>
public sealed class AcmeRequestException : AcmeException
{
    /// <summary>
    /// Creates an exception with the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public AcmeRequestException(string message)
        : base(message)
    {
    }
}
