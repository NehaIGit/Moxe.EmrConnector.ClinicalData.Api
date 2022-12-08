using Autofac;
using Moxe.EmrConnector.ExampleEmr.Connector.Connector;

namespace Moxe.EmrConnector.ExampleEmr.Connector.Startup;

public class ExampleEmrConnectorModule  : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<IPatientSearchConnector>().As<PatientSearchConnector>();
    }
}