namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

/// <summary>
/// Model for finding Patients by Identifiers
/// </summary>
public class PatientSearchByIdentifierRequest : Identifier
{
}

/// <summary>
/// Model for finding Patients by demographics matching.
/// </summary>
public class PatientSearchByDemographicsRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // Todo: Date-only data type from .NET 6
    public DateOnly DateOfBirth { get; set; }
}