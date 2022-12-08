namespace Moxe.EmrConnector.ClinicalData.Api.Manifest;

public enum ResourceSupportLevel
{
    /// <summary>
    /// The resource is is not implemented
    /// </summary>
    None,

    /// <summary>
    /// The resource is implemented, but only provides
    /// a subset of the expected functionality.
    /// </summary>
    Partial,

    /// <summary>
    /// The resource is implemented in such a way that
    /// all expected functionality is available.
    /// </summary>
    Full,
}