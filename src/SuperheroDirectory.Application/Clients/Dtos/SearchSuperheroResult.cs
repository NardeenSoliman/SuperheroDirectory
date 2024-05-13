using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class SearchSuperheroResult : BaseResponse
    {
        public List<Superhero> Results { set; get; }
    }
}
