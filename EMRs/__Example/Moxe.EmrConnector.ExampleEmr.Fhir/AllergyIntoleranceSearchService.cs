using Hl7.Fhir.Model;
using Moxe.EmrConnector.ClinicalData.Api;
using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ClinicalData.Api.Model.Response;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Moxe.EmrConnector.ExampleEmr.Fhir
{
    public class AllergyIntoleranceSearchService : IAllergyIntoleranceSearchByIdentifierService, IAllergyIntoleranceSearchByPatient, IAllergyIntoleranceSearchByPatientAndStatus
    {
        private readonly IAllergyIntoleranceSearchConnector _allergySearch;

        public AllergyIntoleranceSearchService(IAllergyIntoleranceSearchConnector allergySearch)
        {
            _allergySearch = allergySearch;
        }


        /// <summary>
        /// It retrieves AllergyIntolerance data using parameters connection object and identifiers. 
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the allergy data</param>
        /// <returns>It returns allergy data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, AllergyIntoleranceSearchRequest request)
        {
            var allergies = await _allergySearch.FindAllergies(connectionInfo, request.PatientIdentifier.IdentifierType, request.PatientIdentifier.IdentifierValue);

            var bundle = await MapAllergies(allergies);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        /// It retrieves AllergyIntolerance data using parameters connection object and patients-id.
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the allergy data</param>
        /// <returns>It returns allergy data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, AllergyIntoleranceSearchRequestByPatient request)
        {

            var allergies = await _allergySearch.FindAllergies(connectionInfo, request.PatientId);

            var bundle = await MapAllergies(allergies);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        /// It retrieves AllergyIntolerance data using parameters connection object, patient-id and clinical-status.
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the allergy data</param>
        /// <returns>It returns allergy data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, AllergyIntoleranceSearchRequestByPatientAndStatus request)
        {
            var allergies = await _allergySearch.FindAllergies(connectionInfo, request.PatientId, request.ClinicalStatus);

            var bundle = await MapAllergies(allergies);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        /// Maps list of allergies to the bundle
        /// </summary>
        /// <param name="allergies"></param>
        /// <returns>It returns bundle object</returns>
        private Task<Bundle> MapAllergies(IEnumerable<AllergyIntolerance> allergies)
        {
            var bundle = new Bundle();

            foreach (var allergy in allergies)
            {
                var fhirAllergy = MapAllergyIntolerance(allergy);
                bundle.AddResourceEntry(fhirAllergy.allergyIntolerance, fhirAllergy.Url);
            }

            return Task.FromResult(bundle);
        }

        private (Hl7.Fhir.Model.AllergyIntolerance allergyIntolerance, string Url) MapAllergyIntolerance(AllergyIntolerance allergyIntolerance)
        {
            // Todo: map using Liquid templates or similar
            throw new NotImplementedException();
        }
    }
}
