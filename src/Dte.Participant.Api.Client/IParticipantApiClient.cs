using System.Collections.Generic;
using System.Threading.Tasks;
using Dte.Participant.Api.Client.Models;
using Dte.Participant.Api.Client.Requests;
using Dte.Participant.Api.Client.Requests.Participants;
using Dte.Participant.Api.Client.Responses.Health;
using Dte.Participant.Api.Client.Responses.ParticipantRegistrations;
using Dte.Participant.Api.Client.Responses.Participants;

namespace Dte.Participant.Api.Client
{
    public interface IParticipantApiClient
    {
        // Health
        Task<HealthResponse> GetHealthAsync(bool includeReady);

        // Participants
        Task DeleteParticipantAccountAsync(DeleteParticipantAccountRequest request);
        Task UpdateParticipantEmailAsync(string participantId, UpdateParticipantEmailRequest request);
        
        // Details
        Task<ParticipantDetailsResponse> GetParticipantDetailsAsync(string participantId);
        Task<ParticipantDetailsResponse> GetParticipantDetailsByEmailAsync(string email);
        Task CreateParticipantDetailsAsync(CreateParticipantDetailsRequest request);
        Task UpdateParticipantDetailsAsync(string participantId, UpdateParticipantDetailsRequest request);
        
        // Demographics
        Task<ParticipantDemographicsResponse> GetParticipantDemographicsAsync(string participantId);
        Task CreateParticipantDemographicsAsync(CreateParticipantDemographicsRequest request);
        Task UpdateParticipantDemographicsAsync(string participantId, UpdateParticipantDemographicsRequest request);
        
        // Suitability
        Task<ParticipantSuitabilityResponse> GetParticipantSuitabilityAsync(long studyId, string participantId);
        
        // Participant Registrations
        Task CreateParticipantRegistrationAsync(CreateParticipantRegistrationRequest request);
        Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantRegistrationsByStudySiteAsync(long studyId, string siteId);
        Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantsRegistrationsByStudyAsync(long studyId, string participantId);
        Task<ParticipantRegistrationResponse> GetParticipantRegistrationByStudySiteAsync(long studyId, string siteId, string participantId);
        Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantsRegistrationByStudySiteStatusAsync(long studyId, string siteId, ParticipantRegistrationStatus status);
        Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantRegistrationsStatusByStudyAsync(long studyId, ParticipantRegistrationStatus status);
        Task SetScreeningParticipantRegistrationAsync(long studyId, string siteId, string participantId);
        Task SetNotSelectedParticipantRegistrationAsync(long studyId, string siteId, string participantId);

    }
}