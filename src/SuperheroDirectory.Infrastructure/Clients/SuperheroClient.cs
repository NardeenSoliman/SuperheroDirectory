using Newtonsoft.Json.Linq;
using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Constants;
using SuperheroDirectory.Application.Dtos.Base;
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
        public async Task<GetSuperheroResult> GetSuperheroById(string superheroId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync($"{superheroId}");
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);

                BaseResponse baseResponse = jObject.ToObject<BaseResponse>();
                Superhero superhero = jObject.ToObject<Superhero>();

                return new GetSuperheroResult
                {
                    Response = baseResponse.Response,
                    Superhero = superhero
                };

            }
            return null;
        }
    }
}
