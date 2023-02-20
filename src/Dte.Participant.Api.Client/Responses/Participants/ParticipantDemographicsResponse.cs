using System;
using System.Collections.Generic;

namespace Dte.Participant.Api.Client.Responses.Participants
{
    public class ParticipantDemographicsResponse
    {
        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }
        public ParticipantAddressResponse Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SexRegisteredAtBirth { get; set; }
        public bool? GenderIsSameAsSexRegisteredAtBirth { get; set; }
        public string EthnicGroup { get; set; }
        public string EthnicBackground { get; set; }
        public bool? Disability { get; set; }
        public string DisabilityDescription { get; set; }
        public IEnumerable<string> HealthConditionInterests { get; set; }
        public bool ConsentContact { get; set; }
        public bool HasDemographics { get; set; }
    }
}