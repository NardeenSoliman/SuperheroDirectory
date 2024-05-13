using SuperheroDirectory.Application.Dtos;
using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class GetFavoriteSuperheroesResult : BaseResponse
    {
        public List<RetreiveFavoriteSuperhero> FavoriteSuperheroes { set; get; }
    }
}
