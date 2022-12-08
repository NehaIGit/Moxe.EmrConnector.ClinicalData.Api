using Autofac;

namespace Moxe.EmrConnector.ClinicalData.Api.Startup;

public static class RegistrationExtensions
{
    public static void RegisterEmrService<TInterface, TImplementation>(this ContainerBuilder builder, Type registrar)
        where TInterface : class
        where TImplementation : TInterface
    {
        builder
            .RegisterType<TImplementation>()!
            .As<TInterface>()
            .WithMetadata("Assembly", typeof(TInterface).Assembly.FullName);
    }
}