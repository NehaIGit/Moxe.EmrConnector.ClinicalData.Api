namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

/// <summary>
/// Base request for patient-level data. This may be use directly, or
/// subclasses created to add additional properties relevant to some
/// Resource requests.
/// </summary>
public class PatientRequest
{
    public Identifier PatientIdentifier { get; set; }
}