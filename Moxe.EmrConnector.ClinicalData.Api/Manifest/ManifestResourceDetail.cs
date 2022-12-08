namespace Moxe.EmrConnector.ClinicalData.Api.Manifest;

public record ManifestResourceDetail
{
    /// <summary>
    /// The name of the resource. Typically this will be the name of a FHIR Resource.
    /// </summary>
    public string ResourceName { get; set; }

    /// <summary>
    /// How fully the resource is implemented, either by the EMR vendor, or by
    /// the connector -- whichever level of support is lower.
    /// </summary>
    public ResourceSupportLevel Supported { get; set; }

    /// <summary>
    /// Any comments that would be useful to know for users of the connector -
    /// any information about limitations, notes about configuration required by
    /// the Provider or EMR Vendor in order for the resource to be useable, etc.
    /// </summary>
    public string? ImplementationNotes { get; set; }
}