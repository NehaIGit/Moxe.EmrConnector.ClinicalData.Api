using Hl7.Fhir.Model;
using Moxe.EmrConnector.ClinicalData.Api;
using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ClinicalData.Api.Model.Response;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encounter = Moxe.EmrConnector.ExampleEmr.Connector.Model.Encounter;
using Task = System.Threading.Tasks.Task;

namespace Moxe.EmrConnector.ExampleEmr.Fhir
{
    public class EncounterSearchService : IEncounterSearchByIdentifierService, IEncounterSearchRequestByDateRange, IEncounterSearchRequestByPatientAndStatus
    {
        private readonly IEncounterSearchConnector _encounterSearch;

        public EncounterSearchService(IEncounterSearchConnector encounterSearch)
        {
            // Injected via Autofac
            _encounterSearch = encounterSearch;
        }

        /// <summary>
        /// It retrieves encounter data using parameters connection object and identifiers.
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the encounter data</param>
        /// <returns>It returns encounter data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, EncountertSearchByIdentifierRequest request)
        {          
            var encounters = await _encounterSearch.FindEncounters(connectionInfo, request.IdentifierType, request.IdentifierValue);

            var bundle = await MapEncounters(encounters);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        ///  It retrieves encounter data using parameters connection object, patient-id and status.
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the encounter data</param>
        /// <returns>It returns encounter data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, EncounterSearchRequestByPatientAndStatus request)
        {
            var encounters = await _encounterSearch.FindEncounters(connectionInfo, request.PatientId,request.Status);

            var bundle = await MapEncounters(encounters);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        ///  It retrieves encounter data using parameters connection object, date range - start date and end date..
        /// </summary>
        /// <param name="connectionInfo">It contains the information to connect with EHR</param>
        /// <param name="request">It contains the request parameters for getting the encounter data</param>
        /// <returns>It returns encounter data as bundle (collection of resources).</returns>
        public async Task<ResourceResponse<Bundle>> Retrieve(ConnectionInfo connectionInfo, EncounterSearchRequestByDateRange request)
        {
            var encounters = await _encounterSearch.FindEncounters(connectionInfo, request.StartDate, request.EndDate);

            var bundle = await MapEncounters(encounters);

            return new ResourceResponse<Bundle>
            {
                Response = bundle,
            };
        }

        /// <summary>
        /// Maps list of encounters to the bundle
        /// </summary>
        /// <param name="encounters">It is the list of encounters</param>
        /// <returns>It returns encounter data as bundle (collection of resources).</returns>    
        private Task<Bundle> MapEncounters(IEnumerable<Encounter> encounters)
        {
            var bundle = new Bundle();

            foreach (var encounter in encounters)
            {
                var fhirEncounter = MapEncounter(encounter);
                bundle.AddResourceEntry(fhirEncounter.Encounter, fhirEncounter.Url);
            }

            return Task.FromResult(bundle);
        }

        private (Hl7.Fhir.Model.Encounter Encounter, string Url) MapEncounter(Encounter encounter)
        {
            // Todo: map using Liquid templates or similar
            throw new NotImplementedException();
        }

     
    }
}
