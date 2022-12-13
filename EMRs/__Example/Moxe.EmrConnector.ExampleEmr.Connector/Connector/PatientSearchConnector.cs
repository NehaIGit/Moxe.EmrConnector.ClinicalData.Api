using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector.Client;
using Moxe.EmrConnector.ExampleEmr.Connector.Model;

namespace Moxe.EmrConnector.ExampleEmr.Connector.Connector;

public interface IPatientSearchConnector
{
    Task<IEnumerable<Patient>> FindPatients(ConnectionInfo connection, string identifierType, string identifierValue);
    Task<IEnumerable<Patient>> FindPatients(ConnectionInfo connection, string firstName, string lastName, DateOnly dateOfBirth);
}

public class PatientSearchConnector : IPatientSearchConnector
{
    private readonly IAuthFactory _authFactory;

    public PatientSearchConnector(IAuthFactory authFactory)
    {
        _authFactory= authFactory;
    }

    /// <summary>
    /// Get the connection to the EHR based on authentication scheme, 
    /// then use that connection to do the patient search using http client object.
    /// </summary>
    /// <param name="connection">It contains the information to connect with EHR</param>
    /// <param name="identifierType">This field used by the healthcare facility to uniquely identify a patient </param>
    /// <param name="identifierValue">This field used by the healthcare facility to uniquely identify a patient </param>
    /// <returns>It returns list of patients</returns>
    public async Task<IEnumerable<Patient>> FindPatients(ConnectionInfo connection, string identifierType, string identifierValue)
    {
        var connectionObj = _authFactory.GetConnectionObject(connection);       
        var httpClient = connectionObj.GetClient(connection);
        var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();


        #region Return Mock Data
        // Update the mock data to match the request and return it
        return
            from patient in DemoPatients
            let mutated = patient with { MBI = identifierValue }
            select mutated;
        #endregion Return Mock Data
    }

    /// <summary>
    /// Get the connection to the EHR based on authentication scheme, 
    /// then use that connection to do the patient search using http client object.
    /// </summary>
    /// <param name="connection">It contains the information to connect with EHR</param>
    /// <param name="firstName">This field is used as filter parameter</param>
    /// <param name="lastName">This field is used as filter parameter</param>
    /// <param name="dateOfBirth">This field is used as filter parameter</param>
    /// <returns>It returns list of patients</returns>
    public async Task<IEnumerable<Patient>> FindPatients(ConnectionInfo connection, string firstName, string lastName, DateOnly dateOfBirth)
    {
        // Real code would do whatever it took to get a connection to the EMR
        // then use that connection to do the patient search.
        var connectionObj = _authFactory.GetConnectionObject(connection);
        var httpClient = connectionObj.GetClient(connection);
        var response = await httpClient.GetAsync("https://example.moxehealth.com/some/api");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();


        #region Return Mock Data
        // Update the mock data to match the request and return it
        return
            from patient in DemoPatients
            let mutated = patient
                with
            {
                PatientFirstName = firstName,
                PatientLastName = lastName,
                PatientDob = dateOfBirth.ToString("yyyy-MM-dd"),
            }
            select mutated;
        #endregion Return Mock Data
    }

    #region Mock data

    private static readonly IEnumerable<Patient> DemoPatients
        = from index in Enumerable.Range(0, 2)
        select new Patient
        {
            PatientId = $"{index}",
            MBI = $"{index:00000000000}",
            // Filler
            PatientDob = new DateOnly(2000 + index, 01, index).ToString(),
            PatientFirstName = $"Bob{index}",
            PatientGender = new[] { "M", "F", "U" }[index % 3],
            PatientLastName = $"Bobberton{index}",
            PatientBillingAddress =
                new Address
                {
                    Line1 = $"Billing Line 1 {index}",
                    Line2 = $"Billing Line 2 {index}",
                    Line3 = $"Billing Line 3 {index}",
                    Line4 = $"Billing Line 4 {index}",
                    City = $"Billing City{index}",
                    CountryCode = $"Billing CNTY{index}",
                    CountyOrRegion = $"Billing CTRY{index}",
                    PostalCode = $"Billing {new string('0', index)}",
                    StateOrProvince = $"Billing X{index}",
                },
            PatientMailingAddress =
                new Address
                {
                    Line1 = $"Billing Line 1 {index}",
                    Line2 = $"Billing Line 2 {index}",
                    Line3 = $"Billing Line 3 {index}",
                    Line4 = $"Billing Line 4 {index}",
                    City = $"Billing City{index}",
                    CountryCode = $"Billing CNTY{index}",
                    CountyOrRegion = $"Billing CTRY{index}",
                    PostalCode = $"Billing {new string('0', index)}",
                    StateOrProvince = $"Billing X{index}",
                },
            PatientResidentialAddress =
                new Address
                {
                    Line1 = $"Billing Line 1 {index}",
                    Line2 = $"Billing Line 2 {index}",
                    Line3 = $"Billing Line 3 {index}",
                    Line4 = $"Billing Line 4 {index}",
                    City = $"Billing City{index}",
                    CountryCode = $"Billing CNTY{index}",
                    CountyOrRegion = $"Billing CTRY{index}",
                    PostalCode = $"Billing {new string('0', index)}",
                    StateOrProvince = $"Billing X{index}",
                },
            PatientPhoneNumbers =
                new Phone[]
                {
                    new()
                    {
                        Usage = (PhoneUsage) ((index + 1) % 7),
                        Number = $"{index:1+0000000000}",
                        Priority = (byte) index,
                    },
                    new()
                    {
                        Usage = (PhoneUsage) ((index + 2) % 7),
                        Number = $"{index:2+0000000000}",
                        Priority = (byte) index,
                    },
                    new()
                    {
                        Usage = (PhoneUsage) ((index + 3) % 7),
                        Number = $"{index:3+0000000000}",
                        Priority = (byte) index,
                    },
                },
        };

    #endregion
}
