using Microsoft.AspNetCore.Mvc.Testing;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;
using SuperheroDirectory.Application.Enums;
using SuperheroDirectory.Tests.Dtos;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SuperheroDirectory.Tests
{
    public class SuperheroApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        public HttpClient _httpClient;

        private const string DefaultUserEmail = "defaultuser@mail.com";

        public SuperheroApiTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task User_can_register()
        {
            HttpResponseMessage result = await RegisterUser("testuser@gmail.com");

            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task RegisteredUser_can_login()
        {
            await RegisterUser();

            LoginResponse loginResponse = await LoginUser();

            Assert.NotNull(loginResponse);
            Assert.NotNull(loginResponse.AccessToken);
        }

        [Fact]
        public async Task SearchSuperhero_by_name_should_return_superhero_for_authorized_user()
        {
            await AuthorizeUser();

            string superheroName = "batman";

            SearchSuperheroResult? searchResponse = await _httpClient.GetFromJsonAsync<SearchSuperheroResult>($"/api/v1/search/{superheroName}");

            Assert.NotNull(searchResponse);
            Assert.Equal(ApiResponse.Success.ToString(), searchResponse.Response, ignoreCase: true);
            Assert.True(searchResponse.Results.Count >= 0);
        }

        [Fact]
        public async Task GetFavoriteSuperheros_should_return_favorites_for_authorized_user()
        {
            await AuthorizeUser();

            GetFavoriteSuperheroesResult getResponse = await _httpClient.GetFromJsonAsync<GetFavoriteSuperheroesResult>($"/api/v1/favorites");

            Assert.NotNull(getResponse);
            Assert.Equal(ApiResponse.Success.ToString(), getResponse.Response, ignoreCase: true);
            Assert.True(getResponse.FavoriteSuperheroes.Count >= 0);
        }

        [Fact]
        public async Task StoreFavoriteSuperheros_should_return_favorites_for_authorized_user()
        {
            await AuthorizeUser();

            List<StoreFavoriteSuperhero> favoriteSuperheroes = new()
            {
                new StoreFavoriteSuperhero { Id = "70" },
                new StoreFavoriteSuperhero { Id = "71" }
            };

            HttpResponseMessage result = await _httpClient.PostAsJsonAsync($"/api/v1/store/favorites", favoriteSuperheroes);

            BaseResponse storeResponse = await result.Content.ReadFromJsonAsync<BaseResponse>();

            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.NotNull(storeResponse);
            Assert.Equal(ApiResponse.Success.ToString(), storeResponse.Response, ignoreCase: true);
        }

        /// <summary>
        /// Register anonymous user.
        /// Ignore bad request response 
        /// for duplicate requests
        /// </summary>
        /// <returns></returns>
        private async Task<HttpResponseMessage> RegisterUser(string email = DefaultUserEmail)
        {
            UserCredentials credentials = GetUserCredentials(email);

            return await _httpClient.PostAsJsonAsync("/identity/register", credentials);
        }

        /// <summary>
        /// login user using static credentials
        /// </summary>
        /// <returns></returns>
        private async Task<LoginResponse> LoginUser(string email = DefaultUserEmail)
        {
            UserCredentials credentials = GetUserCredentials(email);

            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("/identity/login", credentials);

            return await result.Content.ReadFromJsonAsync<LoginResponse>();
        }

        /// <summary>
        /// get static credentials
        /// </summary>
        /// <returns></returns>
        private UserCredentials GetUserCredentials(string email)
        {
            return new UserCredentials()
            {
                Email = email,
                Password = "c0Mpl#xP@ss"
            };
        }

        /// <summary>
        /// inject http client with authorization header
        /// </summary>
        /// <returns></returns>
        private async Task AuthorizeUser()
        {
            await RegisterUser();
            LoginResponse loginResponse = await LoginUser();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
        }
    }
}
