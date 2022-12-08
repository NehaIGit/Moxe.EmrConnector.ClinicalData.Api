using Moxe.EmrConnector.ClinicalData.Api.Services;

namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

public class ConnectionInfo
{
    /// <summary>
    /// The identifier of this connection. Primarily used in logging - this value must be
    /// included in all log messages related to connection issues (ex: authentication
    /// errors, unreachable host, connection timeout, etc.).
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Identifies the organization that owns the system being connected to.
    /// This can be used for logging, or for scenarios where mapping may need to vary by
    /// the organization instead of just by the EMR type or version.
    /// </summary>
    public string OrganizationCode { get; set; }

    /// <summary>
    /// The base URI of the service(s) being accessed for the EMR. Resource-specific suffixes
    /// are appended to this base URI.
    /// </summary>
    public string URL { get; set; }

    /// <summary>
    /// The <seealso cref="Credential">credentials</seealso> used to authenticate connections
    /// to the EMR.
    /// </summary>
    public Credential Credential { get; set; }

    /// <summary>
    /// Where appropriate, the Client ID used for the connection. Usage varies by connection
    /// type.
    /// </summary>
    public string ClientId { get; set; }


    /// <summary>
    /// Concurrency configuration for the target APIs. To be used in conjunction with
    /// the <c>Moxe.RateLimiterClient</c> NuGet package.
    /// </summary>
    public RateLimitPolicy RateLimitPolicy { get; set; }
}