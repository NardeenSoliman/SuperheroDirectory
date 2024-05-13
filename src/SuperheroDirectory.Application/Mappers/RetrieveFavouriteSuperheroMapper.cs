using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Mappers.Base;
using SuperheroDirectory.Domain.Models;

namespace SuperheroDirectory.Application.Mappers
{
    public class RetrieveFavouriteSuperheroMapper : IModelMapper<FavouriteSuperhero, RetreiveFavoriteSuperhero>
    {
        public RetreiveFavoriteSuperhero Map(FavouriteSuperhero model)
        {
            return new RetreiveFavoriteSuperhero()
            {
                Id = model.SuperheroId,
                Name = model.SuperheroName
            };
        }

        public List<RetreiveFavoriteSuperhero> MapList(List<FavouriteSuperhero> models)
        {
            List<RetreiveFavoriteSuperhero> favoriteSuperheroes = new();
            foreach (FavouriteSuperhero favouriteSuperhero in models)
            {
                favoriteSuperheroes.Add(Map(favouriteSuperhero));
            }
            return favoriteSuperheroes;
        }
    }
}
