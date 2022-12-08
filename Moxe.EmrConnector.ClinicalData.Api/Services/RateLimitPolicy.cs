namespace Moxe.EmrConnector.ClinicalData.Api.Services;

/// <summary>
/// Contains the settings for the concurrency limits of a connection to an external API.
/// </summary>
public class RateLimitPolicy
{
    /// <summary>
    /// A unique identifier for this connection's limits, used to correlate concurrency across
    /// distributed workers that are trying to access the same API.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// How long the token is held by the Rate Limiting Service before the lock expires and
    /// the rate limit "slot" is freed for other tasks to use.
    /// </summary>
    public TimeSpan? TokenTimeout { get; set; }

    /// <summary>
    /// Maximum number of concurrent tasks that are allowed.
    /// </summary>
    public uint MaxConcurrent { get; set; }

    /// <summary>
    /// Maximum number of tasks that can be started per second.
    /// </summary>
    public uint MaxPerSecond { get; set; }

    /// <summary>
    /// Works with <see cref="MaxPerSecond"/> to provide a maximum "capacity" to the
    /// flow limiter.
    /// </summary>
    public uint MaxBurstPerSecond { get; set; }
}