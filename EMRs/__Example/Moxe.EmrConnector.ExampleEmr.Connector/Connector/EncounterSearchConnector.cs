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
        /// Get the connection to the EHR, then use that connection to do the encounetr search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="identifierType"></param>
        /// <param name="identifierValue"></param>
        /// <returns></returns>
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
        /// Get the connection to the EHR, then use that connection to do the encounter using search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="patientId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Encounter>> FindEncounters(ConnectionInfo connection, int patientId, string status)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<Encounter>();
        }

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
