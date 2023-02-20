using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dte.Common.Http;
using Dte.Participant.Api.Client.Models;
using Dte.Participant.Api.Client.Requests;
using Dte.Participant.Api.Client.Requests.Participants;
using Dte.Participant.Api.Client.Responses.Health;
using Dte.Participant.Api.Client.Responses.ParticipantRegistrations;
using Dte.Participant.Api.Client.Responses.Participants;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dte.Participant.Api.Client
{
    public class ParticipantApiClient : BaseHttpClient, IParticipantApiClient
    {
        private readonly ILogger<ParticipantApiClient> _logger;

        public ParticipantApiClient(HttpClient httpClient, IHeaderService headerService, ILogger<ParticipantApiClient> logger) 
            : base(httpClient, headerService, logger, ApiClientConfiguration.Default)
        {
            _logger = logger;
        }

        protected override string ServiceName => "ParticipantService";

        public async Task<HealthResponse> GetHealthAsync(bool includeReady)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/health/{(includeReady ? "ready" : "")}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<HealthResponse>(httpRequest);

            return response;
        }

        public async Task DeleteParticipantAccountAsync(DeleteParticipantAccountRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri("api/participants/deleteparticipantaccount", UriKind.Relative),
                Method = HttpMethod.Delete,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task UpdateParticipantEmailAsync(string participantId, UpdateParticipantEmailRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{participantId}/updateparticipantemail", UriKind.Relative),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task<ParticipantDetailsResponse> GetParticipantDetailsAsync(string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{participantId}/details", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<ParticipantDetailsResponse>(httpRequest);

            return response;
        }
        
        public async Task<ParticipantDetailsResponse> GetParticipantDetailsByEmailAsync(string email)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{email}/detailsbyemail", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<ParticipantDetailsResponse>(httpRequest);

            return response;
        }

        public async Task CreateParticipantDetailsAsync(CreateParticipantDetailsRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/details", UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task UpdateParticipantDetailsAsync(string participantId, UpdateParticipantDetailsRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{participantId}/details", UriKind.Relative),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task<ParticipantDemographicsResponse> GetParticipantDemographicsAsync(string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{participantId}/demographics", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<ParticipantDemographicsResponse>(httpRequest);

            return response;
        }

        public async Task CreateParticipantDemographicsAsync(CreateParticipantDemographicsRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/demographics", UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task UpdateParticipantDemographicsAsync(string participantId, UpdateParticipantDemographicsRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{participantId}/demographics", UriKind.Relative),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task<ParticipantSuitabilityResponse> GetParticipantSuitabilityAsync(long studyId, string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/suitability/{studyId}/participant/{participantId}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<ParticipantSuitabilityResponse>(httpRequest);

            return response;
        }

        public async Task CreateParticipantRegistrationAsync(CreateParticipantRegistrationRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/participantregistrations", UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantRegistrationsByStudySiteAsync(long studyId, string siteId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participantregistrations/{studyId}/sites/{siteId}/participants", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<IEnumerable<ParticipantRegistrationResponse>>(httpRequest);

            return response;
        }

        public async Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantsRegistrationsByStudyAsync(long studyId, string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participantregistrations/{studyId}/participants/{participantId}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<IEnumerable<ParticipantRegistrationResponse>>(httpRequest);

            return response;
        }

        public async Task<ParticipantRegistrationResponse> GetParticipantRegistrationByStudySiteAsync(long studyId, string siteId, string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{studyId}/sites/{siteId}/participants/{participantId}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<ParticipantRegistrationResponse>(httpRequest);

            return response;
        }

        public async Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantsRegistrationByStudySiteStatusAsync(long studyId, string siteId, ParticipantRegistrationStatus status)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participantregistrations/{studyId}/sites/{siteId}/participantstatus/{status}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<IEnumerable<ParticipantRegistrationResponse>>(httpRequest);

            return response;
        }

        public async Task<IEnumerable<ParticipantRegistrationResponse>> GetParticipantRegistrationsStatusByStudyAsync(long studyId, ParticipantRegistrationStatus status)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participantregistrations/{studyId}/participants/status/{status}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<IEnumerable<ParticipantRegistrationResponse>>(httpRequest);

            return response;
        }

        public async Task SetScreeningParticipantRegistrationAsync(long studyId, string siteId, string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{studyId}/sites/{siteId}/participants/{participantId}/screening", UriKind.Relative),
                Method = HttpMethod.Post
            };
            
            await SendAsync<object>(httpRequest);
        }

        public async Task SetNotSelectedParticipantRegistrationAsync(long studyId, string siteId, string participantId)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/participants/{studyId}/sites/{siteId}/participants/{participantId}/notselected", UriKind.Relative),
                Method = HttpMethod.Post
            };
            
            await SendAsync<object>(httpRequest);
        }
    }
}
