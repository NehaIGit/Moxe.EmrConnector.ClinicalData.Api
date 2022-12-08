namespace Moxe.EmrConnector.ExampleEmr.Connector.Model;

/**
 * Made up models to demonstrate awful APIs from awful 3rd parties
 */

public record Patient
{
    public string PatientId { get; set; }
    public string MBI { get; set; }
    public string PatientFirstName { get; set;}
    public string PatientLastName { get; set;}
    public string PatientDob { get; set;}
    public string PatientGender { get; set;}
    public Address PatientResidentialAddress { get; set;}
    public Address PatientMailingAddress { get; set;}
    public Address PatientBillingAddress { get; set;}
    public Phone[] PatientPhoneNumbers { get; set; }
}

public record ActiveHours
{
    public DayOfWeek[] Days { get; set; }
    public (TimeOnly[] StartTime, TimeOnly[] EndTime)[] AvailableTimes { get; set; }
}

public enum PhoneUsage
{
    DoNotCall = 0,
    Home = 1,
    Work = 2,
    Mobile = 3,
    Fax = 4,
    Pager = 5,
    EmergencyContact = 6,
}

public record Phone
{
    public PhoneUsage Usage { get; set; }
    public byte Priority { get; set; }
    public string Number { get; set; }
}

public record Address
{
    public string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public string? Line4 { get; set; }
    public string City { get; set; }
    public string? CountyOrRegion { get; set; }
    public string StateOrProvince { get; set; }
    public string PostalCode { get; set; }
    public string? CountryCode { get; set; }
}