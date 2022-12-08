namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

public enum AuthenticationScheme
{
    None = 0,
    UsernamePassword = 1,
    DigitalSignature = 2,
    Secret = 3,
    OAuthJwtClientAssertion = 4
}