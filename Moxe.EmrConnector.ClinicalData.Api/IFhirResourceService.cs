using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ClinicalData.Api.Model.Response;

namespace Moxe.EmrConnector.ClinicalData.Api;

public interface IFhirResourceService<in TRequest, TResource> 
    where TResource : Hl7.Fhir.Model.Resource
{
    Task<ResourceResponse<TResource>> Retrieve(ConnectionInfo connectionInfo, TRequest request);
}


/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.Patient"/> resources
/// </summary>
public interface IPatientSearchByIdentifierService 
    : IFhirResourceService<PatientSearchByIdentifierRequest, Hl7.Fhir.Model.Bundle> { }

/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.Patient"/> resources
/// </summary>
public interface IPatientSearchByDemographicsService
    : IFhirResourceService<PatientSearchByDemographicsRequest, Hl7.Fhir.Model.Bundle> { }

/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.Encounter"/> resources
/// </summary>
public interface IEncounterSearchByIdentifierService
    : IFhirResourceService<EncountertSearchByIdentifierRequest, Hl7.Fhir.Model.Bundle>
{ }

/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.Encounter"/> resources
/// </summary>
public interface IEncounterSearchRequestByDateRange
    : IFhirResourceService<EncounterSearchRequestByDateRange, Hl7.Fhir.Model.Bundle> { }

/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.Encounter"/> resources
/// </summary>
public interface IEncounterSearchRequestByPatientAndStatus
    : IFhirResourceService<EncounterSearchRequestByPatientAndStatus, Hl7.Fhir.Model.Bundle>
{ }

/// <summary>
/// Returns a <see cref="Hl7.Fhir.Model.Bundle"/>
/// containing <see cref="Hl7.Fhir.Model.AllergyIntolerance"/> resources
/// </summary>
public interface IAllergyIntoleranceSearchByIdentifierService
    : IFhirResourceService<AllergyIntoleranceSearchRequest, Hl7.Fhir.Model.Bundle>
{ }

public interface IAllergyIntoleranceSearchByPatient
    : IFhirResourceService<AllergyIntoleranceSearchRequestByPatient, Hl7.Fhir.Model.Bundle>
{ }

public interface IAllergyIntoleranceSearchByPatientAndStatus
    : IFhirResourceService<AllergyIntoleranceSearchRequestByPatientAndStatus, Hl7.Fhir.Model.Bundle>
{ }


/**
 * Todo: build out remaining interfaces for:
 *  - Patient Allergies
 *  - Patient Medications
 *  - Patient Immunizations
 *  - Patient Problems
 *  - Encounter Diagnoses
 *  - Encounter Observations
 *  - Encounter Procuedures
 *  - Encounter Clinical Notes
 *  - Encounter Vitals
 *  - Encounter Medications
 *  - Encounter Social History
 *  - Encounter Family History
 *  - Encounter Location
 *  - Encounter Practitioner
 *  - Encounter Organization
 *
 * Todo: define APIs required by Convergence
 */
