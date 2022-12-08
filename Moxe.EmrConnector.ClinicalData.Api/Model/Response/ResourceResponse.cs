namespace Moxe.EmrConnector.ClinicalData.Api.Model.Response;

/// <summary>
/// Envelope around a FHIR R4 Response object where additional future metadata
/// may be added, or subclasses can add additional properties to contextualize
/// the response data. The <typeparamref name="TResource"/> can be either a
/// <see cref="Hl7.Fhir.Model.Bundle"/> of many Resources, or a single Resource.
/// </summary>
/// <typeparam name="TResource">A FHIR R4 <see cref="Hl7.Fhir.Model.Resource"/> model</typeparam>
public class ResourceResponse<TResource> where TResource : Hl7.Fhir.Model.Resource
{
    public TResource Response { get; set; }
}