using Autofac;
using Moxe.EmrConnector.ClinicalData.Api;
using Moxe.EmrConnector.ClinicalData.Api.Manifest;
using Moxe.EmrConnector.ClinicalData.Api.Startup;
using Moxe.EmrConnector.ExampleEmr.Fhir.Manifest;

namespace Moxe.EmrConnector.ExampleEmr.Fhir.Startup;

public class ExampleEmrFhirModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<ExampleEmrConnectorManifest>().As<IConnectorManifest>();

        #region Register FHIR data services

        builder.RegisterEmrService<IPatientSearchByIdentifierService, PatientSearchService>(GetType());
        builder.RegisterEmrService<IPatientSearchByDemographicsService, PatientSearchService>(GetType());

        #endregion Register FHIR data services
    }
}