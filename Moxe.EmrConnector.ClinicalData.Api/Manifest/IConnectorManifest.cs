using System.Reflection;

namespace Moxe.EmrConnector.ClinicalData.Api.Manifest;

public interface IConnectorManifest
{
    /// <summary>
    /// The name of the EMR
    /// </summary>
    string EmrName { get; }

    /// <summary>
    /// The range of versions of the EMR that are supported by the implementing connector.
    /// </summary>
    (string LowestVersion, string? HighestVersion) EmrVersionRange { get; }

    /// <summary>
    /// The version of the connector; typically the <see cref="AssemblyName.Version"/>.
    /// </summary>
    Version ConnectorVersion { get; }

    /// <summary>
    /// For each type of resource, details about whether it is supported, and any comments
    /// about the resource that describe limitations or notes that are relevant to implementing
    /// and using the resource in other applications.
    /// </summary>
    IEnumerable<ManifestResourceDetail> SupportedResourceTypes { get; }
}