namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request;

public class Identifier
{
    /// <summary>
    /// Type of the <see cref="IdentifierValue"/>
    /// </summary>
    public string IdentifierType { get; set; }

    /// <summary>
    /// The value of the identifier.
    /// </summary>
    public string IdentifierValue { get; set; }
}