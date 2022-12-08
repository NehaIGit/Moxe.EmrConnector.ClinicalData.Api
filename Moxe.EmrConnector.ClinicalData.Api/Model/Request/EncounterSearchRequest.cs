namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

public class EncountertSearchByIdentifierRequest : Identifier
{
}
/// <summary>
/// Base encounter search request, by Patient and a range of Dates.
/// </summary>
public class EncounterSearchRequestByDateRange : PatientRequest
{
    /// <summary>
    /// Earliest encounter start date to retrieve.
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// Latest encounter start date to retrieve.
    /// </summary>
    public DateOnly EndDate { get; set; }
    public int PatientId { get; set; }
    public string Status { get; set; }
}
public class EncounterSearchRequestByPatientAndStatus
{
    /// <summary>
    /// Earliest encounter start date to retrieve.
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// Latest encounter start date to retrieve.
    /// </summary>
    public DateOnly EndDate { get; set; }
    public int PatientId { get; set; }
    public string Status { get; set; }
}
