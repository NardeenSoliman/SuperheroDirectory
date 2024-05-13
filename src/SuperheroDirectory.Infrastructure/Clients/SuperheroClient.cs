using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Constants;
using System.Net.Http.Json;

namespace SuperheroDirectory.Infrastructure.Clients
{
    public class SuperheroClient : ISuperheroClient
    {
        private readonly HttpClient _httpClient;

        public SuperheroClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SearchSuperheroResult> SearchSuperhero(string superheroName)
        {
            HttpResponseMessage result = await _httpClient.GetAsync($"{Routes.Search}/{superheroName}");
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<SearchSuperheroResult>();
            return null;
        }
    }
}
