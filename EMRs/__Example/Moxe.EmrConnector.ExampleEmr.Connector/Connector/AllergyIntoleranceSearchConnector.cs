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
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the allergy search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR</param>
        /// <param name="identifierType">This field used by the healthcare facility to uniquely identify the allergy </param>
        /// <param name="identifierValue">This field used by the healthcare facility to uniquely identify the  allergy </param>
        /// <returns>It returns list of allergies</returns>
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
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the allergy search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR</param>
        /// <param name="patientId">This is the primary identifier to collect the patient data</param>
        /// <returns>It returns list of allergies</returns>
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
        /// Get the connection to the EHR bases on authentication scheme, 
        /// then use that connection to do the allergy search using http client object.
        /// </summary>
        /// <param name="connection">It contains the information to connect with EHR></param>
        /// <param name="patientId">This is the primary identifier to collect the patient data</param>
        /// <param name="clinicalStatus">This is the clinical status of the patient.</param>
        /// <returns>It returns list of allergies</returns>
        public async Task<IEnumerable<AllergyIntolerance>> FindAllergies(ConnectionInfo connection, int patientId, string clinicalStatus)
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
