using Hl7.Fhir.Utility;
using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector.Client;
using Moxe.EmrConnector.ExampleEmr.Connector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moxe.EmrConnector.ExampleEmr.Connector.Connector
{
    public interface IEncounterSearchConnector
    {
        Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, string identifierType, string identifierValue);
        Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, int patientId, string status);
        Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, DateOnly startDate, DateOnly EndDate);

    }
    public class EncounterSearchConnector : IEncounterSearchConnector
    {
        private readonly IAuthFactory _authFactory;

        public EncounterSearchConnector(IAuthFactory authFactory)
        {
            _authFactory= authFactory;
        }
        /// <summary>
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the encounter search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR</param>
        /// <param name="identifierType">This field used by the healthcare facility to uniquely identify the encounter </param>
        /// <param name="identifierValue">This field used by the healthcare facility to uniquely identify the encounter </param>
        /// <returns>It returns list of encounters</returns>
        public async Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, string identifierType, string identifierValue)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);           
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();        

            return new List<Encounter>();
        }
        /// <summary>
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the encounter search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR</param>
        /// <param name="patientId">This field used by the healthcare facility to uniquely identify a patient</param>
        /// <param name="status"> This is the clinical status of the patient</param>
        /// <returns>It returns list of encounters</returns>
        public async Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, int patientId, string status)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<Encounter>();
        }

        /// <summary>
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the encounter search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR</param>
        /// <param name="startDate"> This is the encounter start date</param>
        /// <param name="EndDate"> This is the encounter end date</param>
        /// <returns>It returns list of encounters</returns>
        public async Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, DateOnly startDate, DateOnly EndDate)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<Encounter>();
        }


    }
}
