namespace Dte.Participant.Api.Client.Requests
{
    public class CreateParticipantRegistrationRequest
    {
        public long StudyId { get; set; }
        public string SiteId { get; set; }
        public string ParticipantId { get; set; }
    }
}