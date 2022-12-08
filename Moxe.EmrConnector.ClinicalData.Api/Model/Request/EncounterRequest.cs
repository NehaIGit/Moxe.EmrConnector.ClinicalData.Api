namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

/// <summary>
/// Base request class for encounter-specific data. This class may be used directly,
/// or be subclassed to add additional properties specific to a resource.
/// </summary>
public class EncounterRequest : PatientRequest
{
    /// <summary>
    /// The identifier for the encounter. May be a FHIR ID, or other identifier (ex: CSN)
    /// </summary>
    public Identifier EncounterIdentifier { get; set; }
}