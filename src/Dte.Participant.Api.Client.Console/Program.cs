using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dte.Common.Exceptions;
using Dte.Common.Http;
using Microsoft.Extensions.Logging;

namespace Dte.Participant.Api.Client.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7001/")
            };
            var authString = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("nihr-dte-study-api" + ":" + ""));
            httpClient.DefaultRequestHeaders.Add("Authorization", authString);

            var headerService = new HeaderService();
            headerService.SetHeader("ConversationId", new[] { Guid.NewGuid().ToString() });
            
            var client = new ParticipantApiClient(httpClient, headerService, new Logger<ParticipantApiClient>(new LoggerFactory()));

            try
            {
                var response = await client.GetParticipantDetailsAsync("4494252a-2b5a-44dd-9a5d-b7dc4e386a3d");

                System.Console.WriteLine($"Success: {response.Email}");
            }
            catch (HttpServiceException ex)
            {
                System.Console.WriteLine($"HttpServiceException ({ex.ServiceName}): " + ex.Message + " : " + string.Join(", ", ex));
            }
            catch (HttpRequestException ex)
            {
                System.Console.WriteLine("HttpRequestException: " + ex);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }
        }
    }
}
