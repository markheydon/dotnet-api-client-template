using System.Text.Json.Serialization;

namespace Acme.Client.Models;

/// <summary>
/// Example API status payload (replace with your upstream model).
/// </summary>
public sealed record StatusResponse
{
    /// <summary>
    /// Status message from the API.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
