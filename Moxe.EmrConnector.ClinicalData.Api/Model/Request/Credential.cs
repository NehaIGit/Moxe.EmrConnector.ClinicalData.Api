#nullable enable

namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

public class Credential
{
    // Todo: is it better to provide an ISecretProvider that knows how to
    //       fetch the secrets from AWS / Config Service, and handle caching
    //       and simply pass the scheme and secret's key?
    public AuthenticationScheme AuthenticationScheme { get; set; }
    
    public string AuthenticationCredentials { get; set; }

}