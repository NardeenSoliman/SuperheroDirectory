using SuperheroDirectory.Domain.Models;

namespace SuperheroDirectory.Domain.Repositories
{
    public interface ISuperheroRepository
    {
        Task AddFavourites(List<FavouriteSuperhero> superheros);
        Task<List<FavouriteSuperhero>> GetFavourites();
    }
}
