#nullable enable

using Moxe;
using Moxe.EmrConnector.ClinicalData.Api;
using Moxe.EmrConnector.ClinicalData.Api.Manifest;

namespace Moxe.EmrConnector.ExampleEmr.Fhir.Manifest;

public class ExampleEmrConnectorManifest : IConnectorManifest
{
    public string EmrName => "Moxe Example EMR";
    public (string LowestVersion, string? HighestVersion) EmrVersionRange => ("1.47-2022-Dec", null);
    public Version ConnectorVersion => GetType().Assembly.GetName().Version!;
    public IEnumerable<ManifestResourceDetail> SupportedResourceTypes => Details;

    private static readonly IList<ManifestResourceDetail> Details
        = new List<ManifestResourceDetail>
        {
            new ManifestResourceDetail
            {
                ResourceName = "PatientSearchByIdentifier",
                Supported = ResourceSupportLevel.Full,
                ImplementationNotes =
                    "Search by Identifier Types 'MRN' and 'MBI' are supported; no other identifier types are supported",
            },
            new ManifestResourceDetail
            {
                ResourceName = "PatientSearchByDemographics",
                Supported = ResourceSupportLevel.Full,
            },
            new ManifestResourceDetail
            {
                ResourceName = "Patient",
                Supported = ResourceSupportLevel.Full,
            }
            // Etc....
        }.AsReadOnly();
}