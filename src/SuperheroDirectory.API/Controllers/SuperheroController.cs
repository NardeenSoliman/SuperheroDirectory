using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;
using SuperheroDirectory.Application.Services.Abstractions;

namespace SuperheroDirectory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class SuperheroController : ControllerBase
    {
        public ISuperheroService _superheroService;

        public SuperheroController(ISuperheroService superheroService)
        {
            _superheroService = superheroService;
        }

        [HttpGet("search/{superheroName}")]
        public async Task<BaseResponse> Search(string superheroName)
        {
            return await _superheroService.SearchSuperhero(superheroName);
        }

        [HttpPost("store/favorites")]
        public async Task<BaseResponse> StoreFavorite(List<StoreFavoriteSuperhero> favoriteSuperheroes)
        {
            return await _superheroService.StoreFavorite(favoriteSuperheroes);
        }

        [HttpGet("favorites")]
        public async Task<GetFavoriteSuperheroesResult> GetFavorite()
        {
            return await _superheroService.GetFavourites();
        }
    }
}
