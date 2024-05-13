using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class GetSuperheroResult : BaseResponse
    {
        public Superhero Superhero { set; get; }
    }
}
