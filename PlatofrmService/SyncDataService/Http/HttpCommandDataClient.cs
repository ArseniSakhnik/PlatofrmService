using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatofrmService.Dtos;

namespace PlatofrmService.SyncDataService.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var content = JsonSerializer.Serialize(plat);
            var encoding = Encoding.UTF8;
            const string mediaType = "application/json";
            
            var httpContent = new StringContent(content, encoding, mediaType);

            var serviceAddress = _configuration["CommandService"];
            var url = $"{serviceAddress}";

            var response = await _httpClient.PostAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync post to commandService was Ok");
            }
            else
            {
                Console.WriteLine("--> Sync post to commandService was no Ok");
            }
        }
    }
}