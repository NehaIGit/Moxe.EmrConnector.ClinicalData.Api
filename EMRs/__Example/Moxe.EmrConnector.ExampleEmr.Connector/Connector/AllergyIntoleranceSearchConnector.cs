using Hl7.Fhir.Model;
using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moxe.EmrConnector.ExampleEmr.Connector.Connector
{
    public interface IAllergyIntoleranceSearchConnector
    {
        Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, string identifierType, string identifierValue);

        Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, int patientId);

        Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, int patientId, string clinicalStatus);

      
    }

    public class AllergyIntoleranceSearchConnector : IAllergyIntoleranceSearchConnector
    {
        private readonly IAuthFactory _authFactory;

        public AllergyIntoleranceSearchConnector(IAuthFactory authFactory)
        {
            _authFactory = authFactory;
        }

        /// <summary>
        /// Get the connection to the EHR, then use that connection to do the allergy search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="identifierType"></param>
        /// <param name="identifierValue"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, string identifierType, string identifierValue)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<AllergyIntolerance>();
        }


        /// <summary>
        /// Get the connection to the EHR, then use that connection to do the allergy search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>

        public async Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, int patientId)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<AllergyIntolerance>();
        }


        /// <summary>
        /// Get the connection to the EHR, then use that connection to do the allergy search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="patientId"></param>
        /// <param name="clinicalStatus"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, int patientId, string clinicalStatus)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<AllergyIntolerance>();
        }

        /// <summary>
        /// Get the connection to the EHR, then use that connection to do the allergy search.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="allergyIntolerance"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, AllergyIntoleranceSearchRequest allergyIntolerance)
        {
            var connectionObj = _authFactory.GetConnectionObject(connection);
            var httpClient = connectionObj.GetClient(connection);
            var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return new List<AllergyIntolerance>();
        }
    }
}
