﻿using Microsoft.AspNetCore.Http;
using SuperheroDirectory.Application.Caching;
using SuperheroDirectory.Application.Clients.Abstractions;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Constants;
using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;
using SuperheroDirectory.Application.Enums;
using SuperheroDirectory.Application.Mappers;
using SuperheroDirectory.Application.Services.Abstractions;
using SuperheroDirectory.Domain.Models;
using SuperheroDirectory.Domain.Repositories;
using System.Security.Claims;

namespace SuperheroDirectory.Application.Services
{
    public class SuperheroService : ISuperheroService
    {
        private readonly ISystemCache _cacheService;
        private readonly ISuperheroClient _superheroClient;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly ISuperheroRepository _superheroRepository;

        public SuperheroService(ISuperheroClient superheroClient, ISystemCache cacheService, IHttpContextAccessor httpAccessor,
            ISuperheroRepository superheroRepository)
        {
            _cacheService = cacheService;
            _superheroClient = superheroClient;
            _httpAccessor = httpAccessor;
            _superheroRepository = superheroRepository;
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
        public async Task<BaseResponse> StoreFavorite(List<StoreFavoriteSuperhero> favoriteSuperheroes)
        {
            if (favoriteSuperheroes.Any(x => !x.IsValid()))
                return new FailureResponse() { Response = ApiResponse.Error.ToString(), Error = Messages.GetError };

            string userId = _httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<FavouriteSuperhero> heroesToBeStored = [];
            List<Task<GetSuperheroResult>> tasks = [];

            foreach (StoreFavoriteSuperhero superhero in favoriteSuperheroes)
            {
                string cacheKey = string.Format(CacheKeys.SuperheroId, superhero.Id);
                SuperheroBase superheroBase = _cacheService.Get<SuperheroBase>(cacheKey);
                if (superheroBase == null)
                    tasks.Add(GetSuperhero(superhero.Id));
                else
                    heroesToBeStored.Add(new FavouriteSuperhero
                    {
                        UserId = userId,
                        SuperheroId = superheroBase.Id,
                        SuperheroName = superheroBase.Name
                    });
            }

            await Task.WhenAll(tasks);

            tasks.ForEach(result => heroesToBeStored.Add(new FavouriteSuperhero
            {
                UserId = userId,
                SuperheroId = result.Result.Superhero.Id,
                SuperheroName = result.Result.Superhero.Name
            }));

            await _superheroRepository.AddFavourites(heroesToBeStored);

            return new BaseResponse() { Response = ApiResponse.Success.ToString() };
        }

        public async Task<GetFavoriteSuperheroesResult> GetFavourites()
        {
            List<FavouriteSuperhero> favouriteSuperheros = await _superheroRepository.GetFavourites();
            List<RetreiveFavoriteSuperhero> favoriteSuperheroes = new RetrieveFavouriteSuperheroMapper().MapList(favouriteSuperheros);

            return new GetFavoriteSuperheroesResult()
            {
                Response = ApiResponse.Success.ToString(),
                FavoriteSuperheroes = favoriteSuperheroes
            };
        }

        private async Task<GetSuperheroResult> GetSuperhero(string superheroId)
        {
            GetSuperheroResult superheroInfo = await _superheroClient.GetSuperheroById(superheroId);

            if (superheroInfo != null)
            {
                string cacheKey = string.Format(CacheKeys.SuperheroId, superheroInfo.Superhero.Id);
                _cacheService.Set<SuperheroBase>(cacheKey, superheroInfo.Superhero);
            }
            return superheroInfo;
        }
    }
}
