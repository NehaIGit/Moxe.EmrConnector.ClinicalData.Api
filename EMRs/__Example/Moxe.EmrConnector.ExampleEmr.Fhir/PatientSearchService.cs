using Hl7.Fhir.Model;
using Moxe.EmrConnector.ClinicalData.Api;
using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ClinicalData.Api.Model.Response;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector;
using Patient = Moxe.EmrConnector.ExampleEmr.Connector.Model.Patient;
using Task = System.Threading.Tasks.Task;

namespace Moxe.EmrConnector.ExampleEmr.Fhir;

public class PatientSearchService : IPatientSearchByIdentifierService, IPatientSearchByDemographicsService
{
    private readonly IPatientSearchConnector _patientSearch;

    public PatientSearchService(IPatientSearchConnector patientSearch)
    {
        // Injected via Autofac
        _patientSearch = patientSearch;
    }

    /// <summary>
    /// Retrieve patient data using parameters identifier
    /// </summary>
    /// <param name="connectionInfo">It contains the information to connect with EHR</param>
    /// <param name="request">It contains the request parameters for getting the patient data</param>
    /// <returns>It returns patient data as bundle (collection of resources).</returns>
    public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, PatientSearchByIdentifierRequest request)
    {
        var patients = await _patientSearch.FindPatients(connectionInfo, request.IdentifierType, request.IdentifierValue);

        var bundle = await MapPatients(patients);

        return new ResourceResponse<Bundle>
        {
            Response = bundle,
        };
    }

    /// <summary>
    /// Retrieve patient data using parameters patient demographics firstname, lastname, dateofbirth
    /// </summary>
    /// <param name="connectionInfo">It contains the information to connect with EHR</param>
    /// <param name="request">It contains the request parameters for getting the patient data</param>
    /// <returns>It returns patient data as bundle (collection of resources).</returns>
    public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, PatientSearchByDemographicsRequest request)
    {
        var patients = await _patientSearch.FindPatients(connectionInfo, request.FirstName, request.LastName, request.DateOfBirth);

        var bundle = await MapPatients(patients);

        return new ResourceResponse<Bundle>
        {
            Response = bundle,
        };
    }

    /// <summary>
    /// Maps list of patients to the bundle
    /// </summary>
    /// <param name="patients"></param>
    /// <returns>It returns bundle object</returns>
    private Task<Bundle> MapPatients(IEnumerable<Patient> patients)
    {
        var bundle = new Bundle();

        foreach (var patient in patients)
        {
            var fhirPatient = MapPatient(patient);
            bundle.AddResourceEntry(fhirPatient.Patient, fhirPatient.Url);
        }

        return Task.FromResult(bundle);
    }

    private (Hl7.Fhir.Model.Patient Patient, string Url) MapPatient(Patient patient)
    {
        // Todo: map using Liquid templates or similar
        throw new NotImplementedException();
    }
}