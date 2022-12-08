using Moxe.EmrConnector.ClinicalData.Api.Model.Request;
using System.Diagnostics.Tracing;

namespace Moxe.EmrConnector.ExampleEmr.Connector.Connector.Client;

public interface IConnectionBuilder
{
    HttpClient GetClient(ConnectionInfo connectionInfo);
}

public class ConnectionBuilderByUsernamePassword : IConnectionBuilder
{
    public HttpClient GetClient(ConnectionInfo connectionInfo)
    {
        // implementation
        return new HttpClient();
    }
}

public class ConnectionBuilderByDigitalSignature : IConnectionBuilder
{
    public HttpClient GetClient(ConnectionInfo connectionInfo)
    {
        // implementation
        return new HttpClient();
    }
}
public class ConnectionBuilderBySecret : IConnectionBuilder
{
    public HttpClient GetClient(ConnectionInfo connectionInfo)
    {
        // implementation
        return new HttpClient();
    }
}
public class ConnectionBuilderByOAuth : IConnectionBuilder
{
    public HttpClient GetClient(ConnectionInfo connectionInfo)
    {
        // Silly example
        return new HttpClient();
    }
}

public interface IAuthFactory
{
    IConnectionBuilder GetConnectionObject(ConnectionInfo connectionInfo);
}

public class AuthFactory : IAuthFactory
{
    public IConnectionBuilder GetConnectionObject(ConnectionInfo connectionInfo)
    {
        var value = connectionInfo.Credential.AuthenticationScheme;

        switch (value)
        {
            case AuthenticationScheme.None:
                return null;

            case AuthenticationScheme.UsernamePassword:
                return new ConnectionBuilderByUsernamePassword();

            case AuthenticationScheme.DigitalSignature:
                return new ConnectionBuilderByDigitalSignature();

            case AuthenticationScheme.Secret:
                return new ConnectionBuilderBySecret();

            case AuthenticationScheme.OAuthJwtClientAssertion:
                return new ConnectionBuilderByOAuth();

            default: return null;

        }
    }
}