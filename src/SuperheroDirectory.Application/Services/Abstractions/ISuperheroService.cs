using SuperheroDirectory.Application.Clients.Dtos;
using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Services.Abstractions
{
    public interface ISuperheroService
    {
        /// <summary>
        /// search superheroes by name
        /// by calling superhero api endpoint
        /// and cache result
        /// </summary>
        /// <param name="superheroName"></param>
        /// <returns></returns>
        public Task<BaseResponse> SearchSuperhero(string superheroName);

        /// <summary>
        /// store user favourite superheroes
        /// in database
        /// </summary>
        /// <param name="favoriteSuperheroes"></param>
        /// <returns></returns>
        public Task<BaseResponse> StoreFavorite(List<StoreFavoriteSuperhero> favoriteSuperheroes);

        /// <summary>
        /// get user favourite superheroes
        /// from database
        /// </summary>
        /// <returns></returns>
        public Task<GetFavoriteSuperheroesResult> GetFavourites();
    }
}
