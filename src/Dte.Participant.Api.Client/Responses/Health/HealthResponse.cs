using System.Collections.Generic;

namespace Dte.Participant.Api.Client.Responses.Health
{
    public class HealthResponse
    {
        public string Status { get; set; }
        public Dictionary<string, HealthResultsResponse> Results { get; set; }
    }
    
    public class HealthResultsResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}