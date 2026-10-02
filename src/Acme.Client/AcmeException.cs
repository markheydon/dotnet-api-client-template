namespace Acme.Client;

/// <summary>
/// Base exception for Example API SDK failures.
/// </summary>
public class AcmeException : Exception
{
    /// <summary>
    /// Creates an exception with the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public AcmeException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Creates an exception with the specified message and inner exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public AcmeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
