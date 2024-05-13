using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Services.Abstractions
{
    public interface ISuperheroService
    {
        public Task<BaseResponse> SearchSuperhero(string superheroName);
        public Task<BaseResponse> StoreFavorite(List<StoreFavoriteSuperhero> favoriteSuperheroes);
        public Task<GetFavoriteSuperheroesResult> GetFavourites();
    }
}
