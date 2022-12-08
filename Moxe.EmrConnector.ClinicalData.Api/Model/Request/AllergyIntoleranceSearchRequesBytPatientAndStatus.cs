using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moxe.EmrConnector.ClinicalData.Api.Model.Request
{
    public class AllergyIntoleranceSearchRequest : PatientRequest
    {
        public int PatientId { get; set; }
        public string ClinicalStatus { get; set;}

    }
    public class AllergyIntoleranceSearchRequestByPatient 
    {

        public int PatientId { get; set; }

    }
    public class AllergyIntoleranceSearchRequestByPatientAndStatus 
    {

        public int PatientId { get; set; }
        public string ClinicalStatus { get; set; }

    }

}
