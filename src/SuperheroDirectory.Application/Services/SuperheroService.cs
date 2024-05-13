using SuperheroDirectory.Application.Caching;
using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Constants;
using SuperheroDirectory.Application.Dtos.Base;
using SuperheroDirectory.Application.Enums;
using SuperheroDirectory.Application.Services.Abstractions;

namespace SuperheroDirectory.Application.Services
{
    public class SuperheroService : ISuperheroService
    {
        private readonly ISystemCache _cacheService;
        private readonly ISuperheroClient _superheroClient;

        public SuperheroService(ISuperheroClient superheroClient, ISystemCache cacheService)
        {
            _cacheService = cacheService;
            _superheroClient = superheroClient;
        }

        public async Task<BaseResponse> SearchSuperhero(string superheroName)
        {
            SearchSuperheroResult searchResult = await _superheroClient.SearchSuperhero(superheroName);
            if (searchResult.Results == null)
                return new FailureResponse() { Response = ApiResponse.Error.ToString(), Error = Messages.SearchError };

            foreach (Superhero superhero in searchResult.Results)
            {
                string cacheKey = string.Format(CacheKeys.SuperheroId, superhero.Id);
                _cacheService.Set<SuperheroBase>(cacheKey, superhero);
            }

            return searchResult;
        }
    }
}
