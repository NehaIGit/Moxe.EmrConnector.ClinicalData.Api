using Moxe.EmrConnector.ClinicalData.Api.Model.Request;

namespace Moxe.EmrConnector.ClinicalData.Api.Services;

/// <summary>
/// Interface for interacting with an external service that provides rate limiting functionality.
/// The implementation of this will be injected via Autofac at runtime.
/// </summary>
public interface IRateLimiter
{
    /// <summary>
    /// Performs an <paramref name="action"/> within a <paramref name="rateLimitPolicy">
    /// rate limited</paramref> scope, intended to prevent problematic load on clients'
    /// infrastructure.
    /// </summary>
    /// <param name="rateLimitPolicy">The concurrency policy for the
    /// <see cref="ConnectionInfo">connection</see>, which will vary by EMR
    /// and provider.</param>
    /// <param name="action">The expression to execute within the rate-limited context</param>
    /// <returns>A <see cref="Task"/> to <c>await</c></returns>
    /// <exception cref="Exception">
    /// Thrown if a lock can not be acquired within the deadline (default: 60s).
    /// </exception>
    Task WithLock(RateLimitPolicy rateLimitPolicy, Func<Task> action);

    /// <summary>
    /// Performs an <paramref name="action"/> within a <paramref name="rateLimitPolicy">
    /// rate limited</paramref> scope, intended to prevent problematic load on clients'
    /// infrastructure.
    /// </summary>
    /// <param name="rateLimitPolicy">The concurrency policy for the
    /// <see cref="ConnectionInfo">connection</see>, which will vary by EMR
    /// and provider.</param>
    /// <param name="action">The expression to execute within the rate-limited context</param>
    /// <returns>A <see cref="Task"/> to <c>await</c></returns>
    /// <exception cref="Exception">
    /// Thrown if a lock can not be acquired within the deadline (default: 60s).
    /// </exception>
    Task<T> WithLock<T>(RateLimitPolicy rateLimitPolicy, Func<Task<T>> action);
}